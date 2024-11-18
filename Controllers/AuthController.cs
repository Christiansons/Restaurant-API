using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Restaurant_API.Models;

namespace Restaurant_API.Controllers
{
	public class AuthController : ControllerBase
	{
		private readonly UserManager<Admin> _userManager;
		private readonly SignInManager<Admin> _signInManager;
		private readonly JwtSettings _jwtSettings;

		public AuthController(UserManager<Admin> userManager, SignInManager<Admin> signInManager, IOptions<JwtSettings> jwtSettings)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_jwtSettings = jwtSettings.Value;

		}
	}
}
