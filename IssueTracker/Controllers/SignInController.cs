using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceModel.Dto;
using ServiceModel.Type;

namespace IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }
        private readonly AuthOptions _authOptions;
        public SignInController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IOptions<AuthOptions> authOptionsAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authOptions = authOptionsAccessor.Value;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateUserRequest userRequest)
        {
            var user = await _userManager.FindByNameAsync(userRequest.Username);
            var result = await _signInManager.PasswordSignInAsync(user, userRequest.Password, false, false);
            if (result.Succeeded)
            {
                return Ok(Createtoken(user.UserName));
            }
            return Unauthorized();
        }

        private object Createtoken(string userName)
        {
            var authClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                expires: DateTime.Now.AddHours(_authOptions.ExpiresInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.SecureKey)),
                    SecurityAlgorithms.HmacSha256Signature)
                );
            return Ok(new
            {
                token= $"Bearer {new JwtSecurityTokenHandler().WriteToken(token)}" ,
                expiration = token.ValidTo
            });
        }
    }
}