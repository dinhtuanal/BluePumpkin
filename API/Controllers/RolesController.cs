using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseResult(404));
            }
            var result = await _roleService.Add(model);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _roleService.Update(model);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        [Route("delete/{roleId}")]
        public async Task<IActionResult> Delete(string roleId)
        {
            var result = await _roleService.Delete(roleId);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_roleService.GetAll());
        }
        [HttpGet]
        [Route("{roleId}")]
        public async Task<IActionResult> GetById(string roleId)
        {
            return Ok(await _roleService.GetById(roleId));
        }
        [HttpPost]
        [Route("assign-role")]
        public async Task<IActionResult> AssignRole(UserRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _roleService.AssignRole(model);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost]
        [Route("remove-role")]
        public async Task<IActionResult> RemoveRole(UserRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _roleService.RemoveRole(model);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet]
        [Route("user-in-role/{roleName}")]
        public async Task<IActionResult> GetUserInRole(string roleName)
        {
            var result = await _roleService.GetUserInRole(roleName);
            return Ok(result);
        }
        [HttpGet]
        [Route("user-not-in-role/{roleName}")]
        public async Task<IActionResult> GetUserNotInRole(string roleName)
        {
            var result = await _roleService.GetUserNotInRole(roleName);
            return Ok(result);
        }
    }
}
