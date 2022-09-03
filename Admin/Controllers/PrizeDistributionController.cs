using Clients.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class PrizeDistributionController : Controller
    {
        private readonly IPrizeDistributionClient _prizeDistributionClient;
        public PrizeDistributionController(IPrizeDistributionClient prizeDistributionClient)
        {
            _prizeDistributionClient = prizeDistributionClient;
        }   

        public async Task<IActionResult> Index()
        {
            var pd = await _prizeDistributionClient.GetAll();
            return View(pd);
        }
        [HttpPost]
        public async Task<JsonResult> Add([FromBody]PrizeDistributionViewModel model)
        {
            var token = User.GetSpecificClaim("token");
            var responseResult = await _prizeDistributionClient.Add(model, token);
            return Json(new {result = responseResult});
        }
    }
}
