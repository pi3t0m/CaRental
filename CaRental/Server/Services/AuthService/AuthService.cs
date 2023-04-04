using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace CaRental.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _contex;

        public AuthService(DataContext contex) 
        {
            _contex = contex;
        }
        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if(await UserExists(user.Email))
            {
                return new ServiceResponse<int> 
                { 
                    Success = false, 
                    Message = "User already exists." 
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PaswordSalt = passwordSalt;

            _contex.Users.Add(user);
            await _contex.SaveChangesAsync();

            return new ServiceResponse<int> { Data = user.Id, Message = "Registration successful!" };
        }

        public async Task<bool> UserExists(string email)
        {
            if(await _contex.Users.AnyAsync(User => User.Email.ToLower()
                .Equals(email.ToLower()))) 
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        } 
    }
}
