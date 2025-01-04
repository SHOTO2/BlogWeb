using BlogWeb.Authontication;
using BlogWeb.Dtos.Users;
using BlogWeb.Interfaces;
using BlogWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogWeb.Repository
{
    public class UserRepository(JwtOptions jwtOptions, ApplicationDbContext context) : IUserRepository
    {
        public async Task<Users?> Createuser(CreateUserDto createUser)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> LoginUser(LoginUserDto loginUser)
        {
            var user = await context.Set<Users>().FirstOrDefaultAsync(U => U.Email == loginUser.Email && U.Password == loginUser.Password);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = jwtOptions.Issuer,
                Audience = jwtOptions.Audiennce,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(jwtOptions.SigningKey)), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new (ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    new (ClaimTypes.Name,user.UserName),
                    new (ClaimTypes.Email,user.Email),
                    new (ClaimTypes.Role,user.UserRole),
                    new ("DateOfBirth",user.DateOfBirth.ToString())
                })
            };
            var securitytoken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securitytoken);
            return accessToken;
        }

        public async Task<Users?> Updateuser(UpdateUserDto updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
