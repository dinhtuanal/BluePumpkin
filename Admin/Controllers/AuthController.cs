    using Clients.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using SharedObjects.Commons;
using SharedObjects.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Admin.Controllers
{
    [Authorize(Roles ="admin")]
    public class AuthController : Controller
    {
        private readonly IUserClient _userClient;
        private readonly IConfiguration _configuration;
        public AuthController(IUserClient userClient, IConfiguration configuration)
        {
            _userClient = userClient;
            _configuration = configuration;

        }
        public async Task<IActionResult> Index()
        {
            var token = User.GetSpecificClaim("token");
            var users = await _userClient.GetAll(token);
            return View(users);
        }

        public IActionResult Add() => View();
        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            var token = User.GetSpecificClaim("token");
            var result = await _userClient.Add(model, token);
            ViewBag.Error = result.Notifications;
            if (result.StatusCode == 200)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            var token = User.GetSpecificClaim("token");
            if (string.IsNullOrEmpty(token))
            {
                return View();
            }
            return RedirectToAction("index","home");
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
            var result = await _userClient.Login(model);
            if (result.StatusCode == 200)
            {

                var userPrincipal = ValidateToken(result.Message);
                var authProperty = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2),
                    IsPersistent = true,
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authProperty);

                return Redirect("Index");
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
        public async Task<IActionResult> Update(string id)
        {
            var token = User.GetSpecificClaim("token");
            var user = await _userClient.GetById(id, token);
            var updateUserVM = new UpdateUserViewModel
            {
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Country = user.Country,
                AvataUrl = user.AvataUrl,
                PhoneNumber = user.PhoneNumber,
                Gender = (int)user.Gender,
                BirthDay = user.BirtthDay
            };
            return View(updateUserVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel model)
        {
            var token = User.GetSpecificClaim("token");
            var result = await _userClient.Update(model, token);
            ViewBag.Error = result.Notifications;
            if (result.StatusCode == 200)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Profile(string username)
        {
            var token = User.GetSpecificClaim("token");
            var userLogin = await _userClient.GetByUserName(username, token);
            return View(userLogin);
        }
    }
}
