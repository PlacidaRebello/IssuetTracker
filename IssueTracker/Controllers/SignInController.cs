using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceModel.Dto;
using ServiceModel.Type;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }
        private readonly AuthOptions _authOptions;
        private readonly IValidator<CreateSignInUserRequest> _createValidator;
        public SignInController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, 
            IOptions<AuthOptions> authOptionsAccessor, IValidator<CreateSignInUserRequest> createValidator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authOptions = authOptionsAccessor.Value;
            _createValidator = createValidator;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateSignInUserRequest userRequest)
        {
            //var res = _createValidator.Validate(userRequest, ruleSet: "Required");
            //if (!res.IsValid)
            //{
            //    foreach (var failure in res.Errors)
            //    {
            //        return failure.ErrorMessage;
            //    }
            //}
            var user = await _userManager.FindByNameAsync(userRequest.Username);
            if (user == null)
            {
                return Unauthorized();
            }
            var result = await _signInManager.PasswordSignInAsync(user, userRequest.Password, false, false);

            if (result.Succeeded)
            {
                return Ok(CreateToken(user.UserName));
            }
            return Unauthorized();
        }

        private object CreateToken(string userName)
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
            return new
            {
                token = $"{new JwtSecurityTokenHandler().WriteToken(token)}",
                expiration = token.ValidTo
            };
        }

        
        
    }
}