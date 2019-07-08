using AspnetRun.Api.Requests;
using AspnetRun.Core.Configuration;
using AspnetRun.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AspnetRunSettings _aspnetRunSettings;
        private readonly SignInManager<AspnetRunUser> _signInManager;
        private readonly UserManager<AspnetRunUser> _userManager;

        public AccountController(SignInManager<AspnetRunUser> signInManager,
          UserManager<AspnetRunUser> userManager,
          IOptions<AspnetRunSettings> options)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _aspnetRunSettings = options.Value;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody]LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                    // Create the token
                    var claims = new[]
                    {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };

                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_aspnetRunSettings.Tokens.Key));
                    var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                      _aspnetRunSettings.Tokens.Issuer,
                      _aspnetRunSettings.Tokens.Audience,
                      claims,
                      expires: DateTime.Now.AddMinutes(30),
                      signingCredentials: signingCredentials);

                    var results = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    };

                    return Created("", results);
                }
            }

            return Unauthorized();
        }
    }
}
