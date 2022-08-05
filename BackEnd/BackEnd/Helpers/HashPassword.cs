using Microsoft.AspNetCore.Identity;

namespace BackEnd.Helpers
{
    public class HashPassword
    {
        public string BCryptHashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(5);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashedPassword;
        }

        public bool BCryptVerifyHashedPassword(string providedPassword, string hashedPassword)
        {
            bool res = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
            if (res)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
