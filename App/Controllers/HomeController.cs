using App.Models;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;
using System.Diagnostics;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEvent _event;
        private readonly IJointEvent _jointEvent;

        public HomeController(ILogger<HomeController> logger, IEvent eventBluePumpkin, IJointEvent jointEvent)
        {
            _logger = logger;
            _event = eventBluePumpkin;
            _jointEvent = jointEvent;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _event.getEvents();
            dynamic myModel = new ExpandoObject();
            myModel.events = events;
            return View(myModel);
        }

        public async Task<IActionResult> Detail(string id)
        {
            dynamic myModel = new ExpandoObject();

            var BluePumpkinEvent = await _event.getEvent(id);
            myModel.BluePumpkinEvent = BluePumpkinEvent;

            var joinevents = await _event.getJoinEvents();
            myModel.Joinevents = joinevents;

            return View(myModel);
        }

        public async Task<JsonResult> JoinEvent(JoinEventViewModel model)
        {
            var token = User.GetSpecificClaim("token");
            var result = await _jointEvent.Add(model, token);
            return Json(new {result = result});
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
    }
}