﻿

using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace Packt.Shared
{
    public static class Protector
    {
        // salt size must be atleast 8 bytes
        private static readonly byte[] salt = Encoding.Unicode.GetBytes("7BANANAS");

        // Iteration must be atleast 1000
        private static readonly int iteration = 2000;

        private static Dictionary<string, User> Users = new Dictionary<string, User>();

        public static void Login(string username, string password)
        { 
            if (CheckPassword(username, password)) 
            {
                var identity = new GenericIdentity(username, "PacktAuth");

                var principal = new GenericPrincipal(identity, Users[username].Roles);

                System.Threading.Thread.CurrentPrincipal = principal;   
            }
        }

        public static User Register(string username, string password, string[] roles = null)
        { 
            // Generate a random salt
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            var saltText = Convert.ToBase64String(saltBytes);

            // Generate the salted and hashed password 
            var saltedHashedPassword = SaltAndHashPassword(password, saltText);

            var user = new User
            {
                Name = username,
                Salt = saltText,
                SaltedHashedPassword = saltedHashedPassword,
                Roles = roles,
            };

            Users.Add(username, user);

            return user;
        }

        public static bool CheckPassword(string username, string password)
        { 
            if (!Users.ContainsKey(username))
            {
                return false;
            }

            var user = Users[username];

            // regenerate the salted and hashed password 
            var saltedHashedPassword = SaltAndHashPassword(password, user.Salt);

            return (saltedHashedPassword == user.SaltedHashedPassword);
        }

        private static string SaltAndHashPassword(string password, string salt)
        { 
            var sha = SHA256.Create();
            var saltedPassword = password + salt;
            return Convert.ToBase64String(
                sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
        }

        public static string Encrypt(string plainText, string password)
        {
            byte[] encryptedBytes;

            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);

            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iteration);
            aes.Key = pbkdf2.GetBytes(32); // set a 256 bit key

            aes.IV = pbkdf2.GetBytes(16); // set a 128 bit IV

            using (var ms = new MemoryStream())
            {
                using (var ce = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    ce.Write(plainBytes, 0, plainBytes.Length);
                }

                encryptedBytes = ms.ToArray();
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string cryptoText, string password)
        {
            byte[] plainBytes;

            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);

            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iteration);
            aes.Key = pbkdf2.GetBytes(32); // set a 256 bit key

            aes.IV = pbkdf2.GetBytes(16); // set a 128 bit IV

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                }

                plainBytes = ms.ToArray();
            }

            return Encoding.Unicode.GetString(plainBytes);
        }
    }
}


