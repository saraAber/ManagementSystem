using System;
using System.Text;
using System.Security.Cryptography;

namespace BLL
{
    public class PasswordHasher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string HashPassword(string password)
        {
            // Convert the plain text password into a byte array using UTF-8 encoding
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

            // StringBuilder is used to efficiently build the final hexadecimal string
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }


}
