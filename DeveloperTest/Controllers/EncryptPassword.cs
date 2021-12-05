using System;
using System.Text;

namespace DeveloperTest.Controllers
{
    public class EncryptPassword
    {
        /// <summary>
        /// Creates a Password Hash to be stored in Database
        /// </summary>
        /// <param name="password">The plain text password</param>
        /// <returns>String of hashed password</returns>
        public static string HashPassword(string password)
        {
            if (password == String.Empty || password == null)
            {
                throw new ArgumentException("Password cannot be null or empty string");
            }

            string hash;

            try
            {
                hash = Convert.ToBase64String(
                    System.Security.Cryptography.SHA256.Create().
                    ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
            catch (Exception e)
            {
                throw new Exception($"Hash failed: {e.Message}");
            }

            return hash;
        }
    }
}