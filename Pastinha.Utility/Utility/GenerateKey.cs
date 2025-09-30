using System.Security.Cryptography;
using System.Text;

namespace Pastinha.Utility.Utility;

public static class GenerateKey
{
    public static StringBuilder GetGenerateKey(decimal amount, byte[] bytes)
    {
        StringBuilder strKey = new();
        for (int i = 0; i < amount; i++)
        {
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            string key = Convert.ToBase64String(bytes);
            strKey.AppendLine(key);
        }
        return strKey;
    }
}
