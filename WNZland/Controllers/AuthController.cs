
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WNZland.Models.DTO;
using WNZland.Repositories;

namespace WNZland.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;
        public AuthController(UserManager<IdentityUser> userManager , ITokenRepository tokenRepository)
        {
this.userManager=userManager;
        }

        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if(identityResult.Succeeded)
            {
                if(registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
               {
                identityResult = await userManager.AddToRolesAsync(identityUser,registerRequestDto.Roles);
                if(identityResult.Succeeded)
                {
                    return Ok("User was registered please login.");
                }
               }
            }
            return BadRequest("Somthing is wrong");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);
            if(user != null)
            {
               var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
               if(checkPasswordResult)
               {
                var roles =await userManager.GetRolesAsync(user);
                if(roles != null)
                {
                    var jweToken =  tokenRepository.CreateJWTToken(user , roles.ToList());
                    var response = new LoginResponseDto
                    {
                        JwtToken = jweToken
                    };
                    return Ok(response);
                }
              
                return Ok();
               }
            }
            return BadRequest("Invalid login attempt");
        }
    }
}
