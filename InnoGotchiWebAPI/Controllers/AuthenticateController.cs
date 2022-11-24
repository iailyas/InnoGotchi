using InnoGotchiWebAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace InnoGotchiWebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public AuthenticateController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }
        [HttpGet("CurrentUser")]

        public async Task<string> GetCurrentUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName
            var applicationUser = await userManager.GetUserAsync(User);

            string user = applicationUser.UserName; // will give the user's Email
            return applicationUser.UserName;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = GetToken(authClaims);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
        [HttpPost("/register")]

        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var userExists = await userManager.FindByNameAsync(registerModel.UserName);
            if (userExists != null)
            {
                return StatusCode(500, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
            IdentityUser user = new()
            {
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.UserName
            };
            var result = await userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
            {
                return StatusCode(500, new Response { Status = "Error", Message = "User already exists!" });
            }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterModel registerModel)
        {
            var userExists = await userManager.FindByNameAsync(registerModel.UserName);
            if (userExists != null)
            {
                return StatusCode(500, new Response { Status = "Error", Message = "User creation failed!" });
            }

            IdentityUser user = new()
            {
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.UserName
            };
            var result = await userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });


        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSinginKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken
                (
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSinginKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }



    }
}
