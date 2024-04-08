using EmpManage.Core.Services;
using EmpManage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    private readonly IAuthService _authService;
    public AuthController(IConfiguration configuration, IAuthService authService)
    {
        _configuration = configuration;
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        if (await _authService.HasAdministrativePosition(loginModel.Identity, loginModel.Lastname))
        {
            var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, "Employee"),
            new Claim(ClaimTypes.Role, "Admin")
        };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWT:Issuer"),
                audience: _configuration.GetValue<string>("JWT:Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString });
        }
        return Unauthorized();
    }

}
