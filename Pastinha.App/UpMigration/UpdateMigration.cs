using Microsoft.EntityFrameworkCore;
using Pastinha.App.RestartAdmin;
using Pastinha.Base.Database;

namespace Pastinha.App.UpMigration;

public static class UpdateMigration
{
    public static void MigrationDataBase()
    {
        var pathMigration = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migration.mig");
        if (!File.Exists(pathMigration))
            return;

        if (!Restart.IsRunningAsAdmin())
        {
            if (MessageBox.Show("Para ralizar a atualização do banco precisa abrir o sistema como administrador.\nDeseja reiniciar como administrador?",
                "Iniciar como Administrador", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Restart.RestartAsAdmin();
                return;
            }
        }

        var connectionString = PastinhaStringConnection.ConnectionString();

        var optionsBuilder = new DbContextOptionsBuilder<PastinhaContext>();
        optionsBuilder.UseSqlite(connectionString);

        using var context = new PastinhaContext(optionsBuilder.Options);
        context.Database.Migrate();
        File.Delete(pathMigration);
        MessageBox.Show("Migração concluída com sucesso", "Processo de migração");
    }
}

