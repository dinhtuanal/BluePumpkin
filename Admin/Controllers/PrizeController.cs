using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class PrizeController : Controller
    {
        private readonly IPrizeClient _prizeClient;
        public PrizeController(IPrizeClient prizeClient)
        {
            _prizeClient = prizeClient;
        }
        public async Task<IActionResult> Index()
        {
            var prizes = await _prizeClient.GetAll();   
            return View(prizes);
        }
    }
}
