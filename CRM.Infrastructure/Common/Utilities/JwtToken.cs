
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CRM.Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CRM.Infrastructure.Utilities;


public class JwtToken
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<SystemUser> _userManager;
    public JwtToken(IConfiguration configuration, UserManager<SystemUser> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }
    public async Task<string> GenerateToken(SystemUser user)
    {


        //create  claims(permission)
        var claims = new List<Claim>
        {new Claim("Id", user.Id.ToString())};
        var roles = await _userManager.GetRolesAsync(user);
        roles.Select(role => { claims.Add(new Claim(ClaimTypes.Role, role)); return role; });



        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["Jwt:ExpireMinutes"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

