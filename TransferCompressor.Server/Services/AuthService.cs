using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TransferCompressor.Server.Models;
using TransferCompressor.Server.Data;
using TransferCompressor.Server.DTO;

namespace TransferCompressor.Server.Services;

public class AuthService(CompressorContext context, IConfiguration configuration) : IAuthService
{
    public async Task<User?> RegisterAsync(UserCreateDto request)
    {
        if (await context.Users.AnyAsync(u => u.username == request.username))
        {
            return null;
        }

        var user = new User();
        var hashedPassword = new PasswordHasher<User>()
            .HashPassword(user, request.password); 
        user.username = request.username;
        user.password = hashedPassword;
        user.email = request.email;
        
        context.Users.Add(user);
        await context.SaveChangesAsync();
        
        return user;
    }

    public async Task<string?> LoginAsync(UserCreateDto request)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.username == request.username);
        if (user is null)
        {
            return null;
        }

        if (new PasswordHasher<User>().VerifyHashedPassword(user, user.password, request.password)
            == PasswordVerificationResult.Failed)
        {
            return null;
        }

        return CreateToken(user) ;
    }
    private string CreateToken(User user)
    {
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.username),
                new Claim(ClaimTypes.NameIdentifier, user.userId.ToString())
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}