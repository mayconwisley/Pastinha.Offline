using Pastinha.Utility.Constant;
using System.Text.RegularExpressions;

namespace Pastinha.Utility.Utility;

public static class NameFolder
{
    public static string GetName(string directory)
    {
        var fullPath = Path.GetFullPath(directory);
        var pathParts = fullPath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

        if (pathParts.Contains(Constants.INACTIVES))
            return Constants.INACTIVES;

        if (pathParts.Contains(Constants.ACTIVES))
            return Constants.ACTIVES;

        // Regex do padrão esperado: 0000-00-00000000
        var patternRegex = @"^\d{4}-\d{2}-\d{8}";

        // Procurar entre os diretórios se algum tem esse padrão
        foreach (var part in pathParts)
        {
            if (Regex.IsMatch(part, patternRegex))
            {
                return part;
            }
        }

        // Retorna o nome da última pasta do caminho como fallback
        return Path.GetFileName(fullPath);
    }
}
