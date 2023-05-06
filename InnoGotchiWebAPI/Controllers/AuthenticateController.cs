using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace InnoGotchiWebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly MainDbContext context;

        public AuthenticateController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, MainDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.context = context;
        }

        [HttpGet("CurrentUser"),Authorize]
        
        public async Task<User> GetCurrentUserName()
        {
            
            var identity = HttpContext.User.Identity.Name;
            if (identity!=null) 
            {
                return await context.User.AsNoTracking().FirstAsync(a => a.UserName == identity);
               
            }
            return null;
        }

        [HttpGet("CurrentUserFarms"), Authorize]

        public async Task<IEnumerable<Farm>> GetCurrentUserFarms()
        {

            var identity = HttpContext.User.Identity.Name;
            if (identity != null)
            {
                var User =  await context.User.AsNoTracking().FirstAsync(a => a.UserName == identity);
                return context.Farm.AsNoTracking().Where(a => a.UserId == User.Id);

            }
            return null;
        }


        [HttpGet("CurrentUserByName"), Authorize]

        public async Task<string> GetCurrentUser()
        {

            var identity = HttpContext.User.Identity.Name;
            if (identity != null)
            {
                return identity;
            }
            return null;
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
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    //user от identityuser<long>
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,UserRoles.User),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                foreach (var authclaim in authClaims) 
                {
                    await userManager.AddClaimAsync(user, authclaim);
                }
                

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                
                return Ok(
                
                    new JwtSecurityTokenHandler().WriteToken(token));
            }
            return Unauthorized();
        }
        [HttpPost("/register")]
       
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
          
            var userExists = await userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                throw new ValidationException("Error. User already exists! ");


            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            await context.Registration.AddAsync(model);
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new ValidationException("Error. User creation failed! Please check user details and try again.");
            //result = await userManager.AddToRoleAsync(user,"Administrator");
            //if (!result.Succeeded)
            //    throw new ValidationException("Error. User creation failed! Please check user details and try again.");

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
