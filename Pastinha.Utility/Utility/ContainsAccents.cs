namespace Pastinha.Utility.Utility;

public class ContainsAccents
{
    public static bool Contain(string texto)
    {
        string acentos = "áàãâäÁÀÃÂÄéèêëÉÈÊËíìîïÍÌÎÏóòõôöÓÒÕÔÖúùûüÚÙÛÜçÇ";
        return texto.Any(c => acentos.Contains(c));
    }
}
