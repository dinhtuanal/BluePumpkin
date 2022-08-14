using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace Admin.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleClient _roleClient;
        public RoleController(IRoleClient roleClient)
        {
            _roleClient = roleClient;
        }
        public async Task<IActionResult> Index()
        {
            var token = User.GetSpecificClaim("token");
            var allRoles = await _roleClient.GetAll(token);
            return View(allRoles);
        }
        public async Task<IActionResult> AddUserInRole(string rolename)
        {
            var token = User.GetSpecificClaim("token");
            var usersNotInRole = await _roleClient.GetUserNotInRole(rolename, token);
            ViewBag.RoleName = rolename;
            return View(usersNotInRole);
        }   
        public async Task<IActionResult> RemoveUserInRole(string rolename)
        {
            var token = User.GetSpecificClaim("token");
            var usersInRole = await _roleClient.GetUserInRole(rolename, token);
            ViewBag.RoleName = rolename;
            return View(usersInRole);
        }
        [HttpPost]
        public async Task<JsonResult> AddUserInRole([FromBody]UserRoleViewModel model)
        {
            var token = User.GetSpecificClaim("token");
            var response = await _roleClient.AssignRole(model, token);
            return Json(new { result = response });
        }
        [HttpPost]
        public async Task<JsonResult> RemoveUserInRole([FromBody] UserRoleViewModel model)
        {
            var token = User.GetSpecificClaim("token");
            var response = await _roleClient.RemoveRole(model, token);
            return Json(new { result = response });
        }
    }
}
