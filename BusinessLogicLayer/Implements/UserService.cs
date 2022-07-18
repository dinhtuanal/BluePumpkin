using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedObjects.Commons;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Implements
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public Task<ResponseResult> Add(AddUserViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new ResponseResult(404, "Email not exists !");
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (!result.Succeeded)
                {
                    return new ResponseResult(400, "Mật khẩu không đúng");
                }
                else
                {
                    //Xử lý khi email và mật khẩu đúng
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim("PhoneNumber", user.PhoneNumber),
                        new Claim("Email" , user.Email),
                        new Claim("Id", user.Id)
                    };
                    // Add các claim thông tin vào ClaimsIdentity
                    var claimsIdentity = new ClaimsIdentity(claims);
                    // Add các claim thông tin quyền vào ClaimsIdentity
                    var roles = (await _userManager.GetRolesAsync(user)).ToList();
                    var claimRoles = new List<Claim>();
                    foreach (var role in roles)
                    {
                        claimRoles.Add(new Claim(ClaimTypes.Role, role));
                    }
                    claimsIdentity.AddClaims(claimRoles);
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken
                    (
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claimsIdentity.Claims,
                        expires: DateTime.UtcNow.AddHours(10),
                        signingCredentials: signIn
                    );
                    string strToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return new ResponseResult(200, strToken);
                }
            }
        }
    }
}
