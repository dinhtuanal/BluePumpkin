using Clients.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class JoinEventController : Controller
    {
        private readonly IJoinEventClient _joinEventClient;
        private readonly IUserClient _userClient;
        private readonly IEventClient _eventClient;
        public JoinEventController(IJoinEventClient joinEventClient, IUserClient userClient, IEventClient eventClient)
        {
            _joinEventClient = joinEventClient;
            _userClient = userClient;
            _eventClient = eventClient;
        }
        public async Task<IActionResult> Index()
        {
            var joinevts = await _joinEventClient.GetAll();
            return View(joinevts);
        }
        public async Task<IActionResult> Add()
        {
            var token = User.GetSpecificClaim("token");
            var users = await _userClient.GetAll(token);
            var events = await _eventClient.GetAll();
            ViewBag.Users = users;
            ViewBag.Events = events;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(JoinEventViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var token = User.GetSpecificClaim("token");
            var result = await _joinEventClient.Add(model, token);
            if (result.StatusCode == 200)
            {
                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}
