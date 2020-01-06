using System.Security.Cryptography;
using System.Text;

namespace URLShortener.Utils
{
    public static class HashGenerator
    {
        public static string Generate_SHA256_Hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                foreach (byte b in hash.ComputeHash(enc.GetBytes(value)))
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
