using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.ViewModels;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        // POST auth/login
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.Login(model);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 404)
            {
                return NotFound();
            }
            return BadRequest(result);
        }
        [HttpPost]
        [Route("add")]
        // POST auth/add
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.Add(model);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 404)
            {
                return NotFound();
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("get-all")]
        // GET /auth/getall
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }
        [HttpGet]
        [Route("get-by-id/{userId}")]
        public async Task<IActionResult> GetById(string userId)
        {
            var user = await _userService.GetById(userId);
            return Ok(user); //json

        }

        [HttpPut]
        [Route("update")]
        // PUT /auth/update
        public async Task<IActionResult> Update(UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.Update(model);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("delete/{userId}")]
        // DELETE auth/{userId}
        public async Task<IActionResult> Delete(string userId)
        {
            var result = await _userService.Delete(userId);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
