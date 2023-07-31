using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UserSpace.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private IConfiguration _config;

    public LoginController(IConfiguration config)
    {
        _config = config;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody] UserLogin userLogin)
    {

        var user = Authenticate(userLogin);

        if (user is null)
        {
            return NotFound();
        }

        var token = Generate(user);

        if (token is null)
        {
            return NotFound();
        }

        return Ok(token);
    }

    private string? Generate(UserModel userLogin)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        Console.WriteLine(userLogin);

        if (userLogin.Username is null ||
            userLogin.GivenName is null ||
            userLogin.Password is null ||
            userLogin.EmailAddres is null ||
            userLogin.Surename is null ||
            userLogin.Role is null)
        {
            return null;
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userLogin.Username),
            new Claim(ClaimTypes.Email, userLogin.EmailAddres),
            new Claim(ClaimTypes.GivenName, userLogin.GivenName),
            new Claim(ClaimTypes.Surname, userLogin.Surename),
            new Claim(ClaimTypes.Role, userLogin.Role)
        };


        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private UserModel? Authenticate(UserLogin user)
    {
        var currentUser = UserConstants.Users.FirstOrDefault(o => o.Username?.ToLower() == user.Username &&
            o.Password == user.Password);

        return currentUser;
    }
}