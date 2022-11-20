using BDU_API.Common;
using Entity.DTOS;
using Entity.DTOS.User;
using Entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BDU_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;
        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, IConfiguration config, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _roleManager = roleManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (userLoginDto.UserEmail?.Trim() == "")
            {
                return BadRequest(new Response(4326, "username is can not  be empty"));
            }
            if(userLoginDto.Password?.Trim() =="")
            {
                return BadRequest(new Response(4325, "user password is can not be empty"));
            }
            //AppUser appUser = await _userManager.FindByNameAsync(userLoginDto.UserId);
            AppUser appUser = await _userManager.FindByEmailAsync(userLoginDto.UserEmail);
            //var result=await _userManager.IsInRoleAsync(appUser, "Telebe");
            if (appUser== null)
            {
                return BadRequest(new Response(4324, "user does not exist"));
            }
            var result = await _signInManager.CheckPasswordSignInAsync(appUser, userLoginDto.Password, true);
            if (result.IsNotAllowed)
            {
                return BadRequest(new Response(4322, "plesae confirm your account"));
            }
            if (result.IsLockedOut)
            {
                return BadRequest(new Response(4323,"the account is blocked"));
            }
            if (!result.Succeeded)
            {
                return BadRequest(new Response(4321, "password is not true"));
            }

            var issuer = _config.GetSection("JWT:issuer").Value;
            var audience = _config.GetSection("JWT:audience").Value;
            var secretLey = _config.GetSection("JWT:secretKey").Value;
#pragma warning disable CS8604 // Possible null reference argument.
            List<Claim> claims = new List<Claim>()
            {
                new Claim("UserID",appUser.Id),
                new Claim("Email",appUser.Email),
                new Claim("FirstName",appUser.FirstName),
                new Claim("LastName",appUser.LastName)
            };

#pragma warning restore CS8604 // Possible null reference argument.
            var roles = await _userManager.GetRolesAsync(appUser);

            claims.AddRange(roles.Select(n => new Claim("role", n)));

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretLey));


            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);


            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
            (
                audience:audience,
                issuer:issuer,
                claims:claims,
                expires:DateTime.UtcNow.AddHours(4).AddMinutes(15),
                signingCredentials:signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);


            return Ok(token);
        }
        //[Authorize(Roles ="Rektor")]
        [Authorize(Roles ="Rektor")]
        [HttpGet]
        public  IActionResult Datas()
        {
            return Ok(new { situation = "permission was needed! " });
        }

        [HttpGet]
        public IActionResult Data()
        {
            return Ok(new {situation="nothing is needed" });
        }
        [Route("/[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateRoles()
        {
#pragma warning disable IDE0058 // Expression value is never used
            await _roleManager.CreateAsync(new IdentityRole("Rektor"));

            await _roleManager.CreateAsync(new IdentityRole("Katib"));
            await _roleManager.CreateAsync(new IdentityRole("Muellim"));
            await _roleManager.CreateAsync(new IdentityRole("Telebe"));
#pragma warning restore IDE0058 // Expression value is never used
            return Ok();
        }


    }
}
