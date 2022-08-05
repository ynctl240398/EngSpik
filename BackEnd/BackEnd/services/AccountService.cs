using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BackEnd.Models;
using BackEnd.EngSpik;
using System.Threading.Tasks;
using System.Linq;
using BackEnd.Helpers;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace BackEnd.services
{
    public class AccountService
    {
        private readonly EngSpikDbContext _app;
        private readonly JwtOptions jwtOptions;

        public AccountService(EngSpikDbContext app)
        {
            _app = app;
            jwtOptions = new JwtOptions();
        }

        private async Task<string> GenerateEncodedToken(string userName, string role)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("roles", role));
            claims.Add(new Claim("username", userName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, await jwtOptions.JtiGenerator()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateHelper.ToUnixEpochDate(jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64));

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: claims,
                notBefore: jwtOptions.NotBefore,
                expires: jwtOptions.Expiration,
                signingCredentials: jwtOptions.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public async Task<ResponseModel<string>> LoginAsync(AccountModel.LoginModel loginModel)
        {
            ResponseModel<string> res = new ResponseModel<string>();
            try
            {
                Account account = await _app.Accounts.FirstOrDefaultAsync(acc => acc.Username.Equals(loginModel.Username));
                if (account == null)
                {
                    res.ErrorCode = -1;
                    res.ErrorMessage = "Email is invalid!";
                }
                else
                {
                    HashPassword hash = new HashPassword();
                    bool check = hash.BCryptVerifyHashedPassword(loginModel.Password, account.Password);
                    if (check)
                    {
                        string role = account.Role == 0 ? "Admin" : account.Role == 1 ? "Speaker" : "User";
                        var jwttoken = await GenerateEncodedToken(loginModel.Username, role);
                        res.ErrorCode = 0;
                        res.Data = jwttoken;
                    }
                    else
                    {
                        res.ErrorCode = -1;
                        res.ErrorMessage = "Password is invalid!";
                    }
                }
            }
            catch (Exception e)
            {
                res.ErrorCode = -1;
                res.ErrorMessage = e.Message;
            }
            return res;
        }

        public async Task<ResponseModel<Account>> RegisterAsync(AccountModel.RegisterModel registerModel)
        {
            ResponseModel<Account> res = new ResponseModel<Account>();
            try
            {
                Account account = await _app.Accounts.FirstOrDefaultAsync(acc => acc.Username.Equals(registerModel.Username));
                if (account != null)
                {
                    res.ErrorCode = -1;
                    res.ErrorMessage = "Email is exist!";
                }
                else
                {
                    account = new Account();
                    HashPassword hash = new HashPassword();
                    account.Password = hash.BCryptHashPassword(registerModel.Password);
                    account.FirstName = registerModel.FirstName;
                    account.LastName = registerModel.LastName;
                    account.Role = registerModel.Role == AccountModel.Role.Admin ? 0 : registerModel.Role == AccountModel.Role.Speaker ? 1 : 2;
                    account.FullName = string.Concat(account.FirstName, " ", account.LastName);
                    account.CreateAt = DateTime.Now;
                    account.Username = registerModel.Username;
                    try
                    {
                        await _app.Accounts.AddAsync(account);
                        _app.SaveChanges();
                        res.ErrorCode = 0;
                        res.Data = account;
                    }
                    catch (Exception e)
                    {
                        res.ErrorCode = -1;
                        res.ErrorMessage = e.Message;
                    }
                }
            }
            catch (Exception e)
            {
                res.ErrorCode = -1;
                res.ErrorMessage = e.Message;
            }
            return res;
        }

        public async Task<ResponseModel<string>> ForgotPasswordAsync(AccountModel.ForgotPasswordModel forgot)
        {
            ResponseModel<string> res = new ResponseModel<string>();
            try
            {
                Account account = await _app.Accounts.FirstOrDefaultAsync(acc => acc.Username.Equals(forgot.Username));
                if (account == null)
                {
                    throw new Exception("Email is not valid!");
                }
                string role = account.Role == 0 ? "Admin" : account.Role == 1 ? "Speaker" : "User";
                var jwttoken = await GenerateEncodedToken(forgot.Username, role);
                res.ErrorCode = 0;
                res.Data = jwttoken;
            }
            catch (Exception e)
            {
                res.ErrorCode = -1;
                res.ErrorMessage = e.Message;
            }
            return res;
        }

        public async Task<ResponseModel<Account>> ChangePassword(AccountModel.ResetPasswordModel reset)
        {
            ResponseModel<Account> res = new ResponseModel<Account>();
            try
            {
                var account = await _app.Accounts.FirstOrDefaultAsync(x => x.Username.Equals(reset.UserName));
                if (account == null)
                {
                    throw new Exception("Account not found!");
                }

                if (!reset.NewPassword.Equals(reset.ConfirmPassword))
                {
                    throw new Exception("Password and confirm password must be same!");
                }

                res.ErrorCode = 0;
                res.Data = account;
            }
            catch (Exception e)
            {
                res.ErrorCode = -1;
                res.ErrorMessage = e.Message;
            }
            return res;
        }

        public string[] DecodeJWT(string jwt)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken tokens = handler.ReadToken(jwt);
            string securityToken = tokens.ToString();
            return securityToken.Split('.', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
