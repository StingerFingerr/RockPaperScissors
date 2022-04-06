using System.Text;
using System.Security.Cryptography;

namespace RockPaperScissors
{
    public static class HMAC
    {
        public static string ComputeHMAC256(string value, string key)
        {
            HMACSHA256 hmac = new HMACSHA256(Encoding.ASCII.GetBytes(key));

            return GetHexValue(hmac.ComputeHash(Encoding.ASCII.GetBytes(value)));
            
        }

        private static string GetHexValue(byte[] array)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append($"{array[i]:X2}");
            }
            return stringBuilder.ToString().ToLower();
        }
    }
}
