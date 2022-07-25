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

        public async Task<ResponseResult> Add(AddUserViewModel model)
        {
            var user = new ApplicationUser();
            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Country = model.Country;
            user.AvataUrl = model.AvataUrl;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Gender = (Gender)model.Gender;
            user.BirtthDay = model.BirthDay;

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return new ResponseResult(200);
            }
            var errors = new List<string>();
            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }
            return new ResponseResult(400, errors);

        }

        public async Task<ResponseResult> Delete(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ResponseResult(404);
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return new ResponseResult(200);
            }
            var errors = new List<string>();
            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }
            return new ResponseResult(400, errors);
        }

        public List<ApplicationUser> GetAll()
        {
            return _userManager.Users.ToList();
        }

        public async Task<ApplicationUser> GetById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new BluePumpkinException("Can not find user");
            }
            else
            {
                return user;
            }
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
                    return new ResponseResult(400, "Password incorrect !");
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

        public async Task<ResponseResult> Update(UpdateUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                throw new BluePumpkinException("Can not fin user");
            }
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Country = model.Country;
            user.AvataUrl = model.AvataUrl;
            user.PhoneNumber = model.PhoneNumber;
            user.Gender = (Gender)model.Gender;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ResponseResult(200, "Update success !");
            }
            var errors = new List<string>();
            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }
            return new ResponseResult(400, errors);
        }
    }
}
