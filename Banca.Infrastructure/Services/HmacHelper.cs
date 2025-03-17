using System.Security.Cryptography;
using System.Text;

namespace Banca.Application.Services
{
    public class HmacHelper
    {
        private static readonly byte[] HmacKey = new byte[] { 6, 2, 6, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };

        public static string ComputeHmac(string data)
        {
            using (var hmac = new HMACSHA256(HmacKey))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyHmac(string data, string hmacValue)
        {
            string computedHmac = ComputeHmac(data);
            return hmacValue == computedHmac;
        }
    }
}
