using System;
namespace BackEnd.Models
{
    public class AccountModel
    {
        public enum Role
        {
            Admin = 0,
            Speaker = 1,
            User = 2
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class RegisterModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Role Role { get; set; }
        }

        public class ForgotPasswordModel
        {
            public string Username { get; set; }
        }

        public class ResetPasswordModel
        {
            public string UserName { get; set; }
            public string NewPassword { get; set; }
            public string ConfirmPassword { get; set; }
        }
    }

}
