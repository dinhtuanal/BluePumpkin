using Clients.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace Admin.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventClient _eventClient;
        public EventController(IEventClient eventClient)
        {
            _eventClient = eventClient;
        }
        public async Task<IActionResult> Index()
        {
            var events = await _eventClient.GetAll();
            return View(events);
        }
        public IActionResult Add() => View();
        [HttpPost]
        public async Task<IActionResult> Add(EventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var token = User.GetSpecificClaim("token");

            var result = await _eventClient.Add(model, token);
            if (result.StatusCode == 200)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Token = token;
            ViewBag.Result = result.StatusCode;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var evt = await _eventClient.GetById(id);
            if (evt == null)
            {
                return RedirectToAction("Index");
            }
            return View(evt);
        }
    }
}
