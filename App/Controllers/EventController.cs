using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
