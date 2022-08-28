using App.Models;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using SharedObjects.Commons;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace App.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUser _user;
        private readonly IConfiguration _configuration;
        public AuthController(IUser user, IConfiguration configuration)
        {
            _user = user;
            _configuration = configuration;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            var token = User.GetSpecificClaim("token");
            if (string.IsNullOrEmpty(token))
            {
                return View();
            }
            return RedirectToAction("index", "home");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _user.Login(model);
            if (result.StatusCode == 200)
            {

                var userPrincipal = ValidateToken(result.Message);
                var authProperty = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2),
                    IsPersistent = true,
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authProperty);

                return RedirectToAction("Index", "home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email or password not correct");
                return View(model);
            }

        }
        private ClaimsPrincipal ValidateToken(string token)
        {
            IdentityModelEventSource.ShowPII = true;
            SecurityToken validateToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.ValidateLifetime = true;
            validationParameters.ValidAudience = _configuration["Jwt:Audience"];
            validationParameters.ValidIssuer = _configuration["Jwt:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out validateToken);

            #region save token as cookie
            var claims = new List<Claim>() { new Claim("token", token), };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);
            principal.AddIdentity(claimsIdentity);
            #endregion
            return principal;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
        [HttpGet]
        public async Task<IActionResult> Profile(string username)
        {
            var token = User.GetSpecificClaim("token");
            var userLogin = await _user.GetByUserName(username, token);
            return View(userLogin);
        }
        public async Task<string> GetUserLoginId()
        {
            var token = User.GetSpecificClaim("token");
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userLogin = await _user.GetByUserName(userName, token);
            var id = userLogin.Id;
            return id;
           
        }
    }
}
