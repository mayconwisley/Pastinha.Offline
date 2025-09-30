using System.Text;

namespace Pastinha.Utility.Utility;

public class RemoveAccents
{
    public static string Remover(string texto)
    {
        StringBuilder sb = new();
        foreach (char c in texto)
        {
            sb.Append(AcentoParaLetra(c));
        }
        return sb.ToString();
    }

    private static char AcentoParaLetra(char c)
    {
        return c switch
        {
            'á' or 'à' or 'ã' or 'â' or 'ä' => 'a',
            'Á' or 'À' or 'Ã' or 'Â' or 'Ä' => 'A',
            'é' or 'è' or 'ê' or 'ë' => 'e',
            'É' or 'È' or 'Ê' or 'Ë' => 'E',
            'í' or 'ì' or 'î' or 'ï' => 'i',
            'Í' or 'Ì' or 'Î' or 'Ï' => 'I',
            'ó' or 'ò' or 'õ' or 'ô' or 'ö' => 'o',
            'Ó' or 'Ò' or 'Õ' or 'Ô' or 'Ö' => 'O',
            'ú' or 'ù' or 'û' or 'ü' => 'u',
            'Ú' or 'Ù' or 'Û' or 'Ü' => 'U',
            'ç' => 'c',
            'Ç' => 'C',
            _ => c,
        };
    }

}
