using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrizeDistributionsController : ControllerBase
    {
        private readonly IPrizeDistributionService _prizeDistributionService;
        public PrizeDistributionsController(IPrizeDistributionService prizeDistributionService)
        {
            _prizeDistributionService = prizeDistributionService;
        }
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_prizeDistributionService.GetAll());
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _prizeDistributionService.GetById(id));
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("add")]
        public async Task<ResponseResult> Add(PrizeDistributionViewModel model)
        {
            var result = await _prizeDistributionService.Add(model);
            if(result ==0)
            {
                return new ResponseResult(400, "Add failed !");
            }
            return new ResponseResult(200, "Add success");
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [HttpPut]
        [Route("update")]
        public async Task<ResponseResult> Update(PrizeDistributionViewModel model)
        {
            var result = await _prizeDistributionService.Add(model);
            if (result == 0)
            {
                return new ResponseResult(400, "Update failed !");
            }
            return new ResponseResult(200, "Update success");
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ResponseResult> Delete(string id)
        {
            var result = await _prizeDistributionService.Delete(id);
            if (result == 0)
            {
                return new ResponseResult(400, "Delete failed !");
            }
            return new ResponseResult(200, "Delete success");
        }
    }
}
