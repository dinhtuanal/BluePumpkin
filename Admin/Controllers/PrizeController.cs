using Clients.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class PrizeController : Controller
    {
        private readonly IPrizeClient _prizeClient;
        private readonly IEventClient _eventClient;
        public PrizeController(IPrizeClient prizeClient, IEventClient eventClient)
        {
            _prizeClient = prizeClient;
            _eventClient = eventClient;
        }
        public async Task<IActionResult> Index()
        {
            var prizes = await _prizeClient.GetAll();
            return View(prizes);
        }
        public async Task<IActionResult> Add()
        {
            var events = await _eventClient.GetAll();
            ViewBag.Events = events;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(PrizeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var token = User.GetSpecificClaim("token");

            var result = await _prizeClient.Add(model, token);
            if (result.StatusCode == 200)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Update(string id)
        {
            var evt = await _prizeClient.GetById(id);
            if (evt == null)
            {
                return RedirectToAction("index");
            }
            ViewBag.Events = await _eventClient.GetAll();
            PrizeViewModel model = new PrizeViewModel
            {
                PrizeId = evt.PrizeId.ToString(),
                PrizeName = evt.PrizeName,
                EventId = evt.EventId.ToString(),
                Content = evt.Content,
                Amount = evt.Amount,
                Distributed = evt.Distributed,
                Status = (int)evt.Status,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(PrizeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var token = User.GetSpecificClaim("token");
            var result = await _prizeClient.Update(model, token);
            if (result.StatusCode == 200)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<JsonResult> GetByEventId(string evtId)
        {
            var prizes = await _prizeClient.GetByEventId(evtId);
            return Json(new {result = prizes});
        }
    }
}
