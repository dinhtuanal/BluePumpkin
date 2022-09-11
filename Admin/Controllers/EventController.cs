using Clients.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace Admin.Controllers
{
    [Authorize(Roles = "admin")]
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
        [HttpPost]
        public async Task<JsonResult> ConfirmDelete(string id)
        {
            var token = User.GetSpecificClaim("token");
            var result = await _eventClient.Delete(id,token);
            return Json(new { result = result });
        }
        public async Task<IActionResult> Update(string id)
        {
            var evt = await _eventClient.GetById(id);
            var evtVM = new EventViewModel
            {
                EventId = id,
                EventName = evt.EventName,
                EventStatus = (int)evt.EventStatus,
                Title = evt.Title,
                ImgUrl = evt.ImgUrl,
                Content = evt.Content,
                TimeStart = evt.TimeStart,
                TimeEnd = evt.TimeEnd,
                CreatedBy = evt.CreatedBy
            };
            ViewBag.ImgUrl = evt.ImgUrl;
            return View(evtVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(EventViewModel model)
        {
            var token = User.GetSpecificClaim("token");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _eventClient.Update(model, token);
            if (result.StatusCode == 200)
            {
                TempData["Success"] = "Update event success !";
                return RedirectToAction("index", "event");
            }
            ViewBag.Result = result.StatusCode;
            return View(model);
        }
    }
}
