using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;

namespace Business
{
    public static class Cls_validate_login
    {

        private static string salt = "$2a$12$KRifz6rfNoX3IKjBpzUjFO";
        public static string GetSalt()
        {
            return salt;
        }

        public static string HashPassword(string password)
        {
            return BCryptHelper.HashPassword(password, salt);
        }

        public static bool ValidatePassword(string password, string correctHash)
        {
            string pass = BCryptHelper.HashPassword(password, salt);

            return pass.Trim().Equals(correctHash.Trim());
           
        }
    }
}
