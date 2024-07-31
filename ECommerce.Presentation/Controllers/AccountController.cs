using ECommerce.Context;
using ECommerce.DTOs.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		public UserManager<ApplicationUser> userManger { get; }
		public IConfiguration configuration { get; }

		public AccountController(UserManager<ApplicationUser> _userManger, IConfiguration _configuration)
		{
			userManger = _userManger;
			configuration = _configuration;
		}

		[Route("Register")]
		[HttpPost]
		public async Task<IActionResult> Register(RegisterDTO registerDTO)
		{
			var ExistingUserReg = await userManger.FindByEmailAsync(registerDTO.Email);
			if (ExistingUserReg != null)
			{
				return Ok("A user with the same Email address already exists");
			}
			ApplicationUser user = new ApplicationUser()
			{
				Email = registerDTO.Email,
				UserName = registerDTO.UserName,
				PhoneNumber = registerDTO.PhoneNumber
			};
			var result = await userManger.CreateAsync(user, registerDTO.Password);

			if (!result.Succeeded)
			{
				return Ok(result.Errors.ElementAt(0));

			}
			return Ok("Created Successfully");
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginDTO loginDTO)
		{
			var ExistingUserLog = await userManger.FindByEmailAsync(loginDTO.Email);
			if (ExistingUserLog == null)
			{
				return Unauthorized();
			}
			var CkeckPass = await userManger.CheckPasswordAsync(ExistingUserLog, loginDTO.Password);
			if (CkeckPass == false)
			{
				return Unauthorized();
			}

			var Claims = new List<Claim>()
			{
				new Claim (ClaimTypes.Name, ExistingUserLog.UserName),
				new Claim (ClaimTypes.Role, "User")
			};
			var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]));
			var SetToken = new JwtSecurityToken(
				expires: DateTime.Now.AddHours(2),
				claims: Claims,
				signingCredentials: new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256),
				issuer: configuration["jwt:issuer"],
				audience: configuration["jwt:audience"]
				);
			var Token = new JwtSecurityTokenHandler().WriteToken(SetToken);
			return Ok(Token);
		}
	}
}
