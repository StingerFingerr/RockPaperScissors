using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissors
{
    public static class KeyGenerator
    {
        public static string GenerateKey()
        {
            byte[] bytes = new byte[32];
            RandomNumberGenerator.Create().GetBytes(bytes);

            return GetHexValue(bytes);
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
