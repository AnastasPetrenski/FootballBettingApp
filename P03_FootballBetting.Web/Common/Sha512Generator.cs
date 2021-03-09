using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Web.Common
{
    public static class Sha512Generator
    {
        public static string Sha512(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            var bytes = Encoding.UTF8.GetBytes(password);
            using var hash = SHA512.Create();

            var hashedInputBytes = hash.ComputeHash(bytes);
            //Convert to text
            //StringBuilder Capacity is 128, coz 512 / 8 bits in byte * 2 symbols for byte

            var sb = new StringBuilder(128);

            foreach (var @byte in hashedInputBytes)
            {
                sb.Append(@byte.ToString("X2"));
            }

            return sb.ToString().Trim();
        }
    }
}
