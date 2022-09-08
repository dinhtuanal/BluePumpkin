using App.Helpers;
using App.Models;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;
using System.Diagnostics;
using System.Dynamic;
using System.Security.Claims;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEvent _event;
        private readonly IJointEvent _jointEvent;
        private readonly IUser _user;

        public HomeController(
            ILogger<HomeController> logger,
            IEvent eventBluePumpkin,
            IJointEvent jointEvent,
            IUser user
            )
        {
            _logger = logger;
            _event = eventBluePumpkin;
            _jointEvent = jointEvent;
            _user = user;
        }

        public async Task<IActionResult> Index()
        {
            var token = User.GetSpecificClaim("token");
            var userLogin = await _user.GetByUserName(User.Identity.Name, token);

            if (userLogin != null)
            {
                ViewBag.UserId = userLogin.Id;
            }

            var events = await _event.getEvents();
            var joinEvents = await _event.getJoinEvents();

            dynamic myModel = new ExpandoObject();

            events.ForEach(item =>
            {
                var joinEvent = joinEvents.Find(x => x.EventId.Equals(item.EventId) && x.UserId.Equals(userLogin?.Id));

                if (joinEvent != null)
                {
                    item.jointEventStatus = Helper.convertJoinEventStatus(joinEvent.JoinEventStatus);
                }

            });

            myModel.joinEvents = joinEvents;
            myModel.events = events;

            return View(myModel);
        }
        [HttpPost]
        public async Task<JsonResult> JoinEvent([FromBody] JoinEventViewModel model)
        {
            var token = User.GetSpecificClaim("token");
            var result = await _jointEvent.Add(model, token);
            return Json(new { result = result });
        }

        public async Task<IActionResult> Detail(string id)
        {
            dynamic myModel = new ExpandoObject();

            var BluePumpkinEvent = await _event.getEvent(id);
            myModel.BluePumpkinEvent = BluePumpkinEvent;

            var joinevents = await _event.getJoinEvents();
            var filterJoinevents = joinevents.FindAll(x => x.EventId.Equals(id));

            filterJoinevents.ForEach(x => x.JoinEventStatus = Helper.convertJoinEventStatus(x.JoinEventStatus));

            myModel.Joinevents = filterJoinevents;

            return View(myModel);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
            var userName = User.FindFirstValue(User.Identity.Name);
            var userLogin = await _user.GetByUserName(userName, token);
            var id = userLogin.Id;
            return id;

        }
    }
}