using App.Models;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEvent _event;

        public HomeController(ILogger<HomeController> logger, IEvent eventBluePumpkin)
        {
            _logger = logger;
            _event = eventBluePumpkin;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _event.getEvents();
            var joinEvents = await _event.getJoinEvents();

            dynamic myModel = new ExpandoObject();

            myModel.joinEvents = joinEvents;
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