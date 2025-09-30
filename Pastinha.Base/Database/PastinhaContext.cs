using Microsoft.EntityFrameworkCore;
using Pastinha.Base.Model.DataFileProcessed;
using Pastinha.Base.Model.Employee;
using Pastinha.Base.Model.FileProcessed;
using Pastinha.Base.Model.Fired;
using Pastinha.Base.Model.Folder;
using Pastinha.Base.Model.FromTo;

namespace Pastinha.Base.Database;

public class PastinhaContext(DbContextOptions<PastinhaContext> options) : DbContext(options)
{
    public DbSet<FolderPastinhaSenior> FoldersPastinha { get; set; }
    public DbSet<CountDataFile> CountDataFiles { get; set; }
    public DbSet<FolderOfflinePastinhaSenior> FoldersOffline { get; set; }
    public DbSet<StatusFired> StatusFireds { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<FileProcessed> FileProcesseds { get; set; }
    public DbSet<FromToCompany> FromToCompanies { get; set; }
    public DbSet<FromToType> FromToTypes { get; set; }
    public DbSet<FromToEmployee> FromToEmployees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountDataFile>()
           .HasIndex(c => c.DateProcess)
           .IsDescending();
        modelBuilder.Entity<Employee>()
           .HasIndex(e => new { e.NumEmp, e.TipCol, e.NumCad })
           .IsUnique();
        modelBuilder.Entity<FileProcessed>()
            .HasIndex(e => new { e.NumEmp, e.TipCol, e.NumCad, e.NomDoc, e.DateProcessed })
            .IsUnique();
        modelBuilder.Entity<FromToCompany>()
            .HasIndex(e => new { e.FromCompany, e.ToCompany })
            .IsUnique();
        modelBuilder.Entity<FromToType>()
            .HasIndex(e => new { e.FromType, e.ToType })
            .IsUnique();
        modelBuilder.Entity<FromToEmployee>()
            .HasIndex(e => new { e.FromEmployee, e.ToEmployee })
            .IsUnique();
    }
}
