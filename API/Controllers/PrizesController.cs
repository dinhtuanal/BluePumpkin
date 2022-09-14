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
    public class PrizesController : ControllerBase
    {
        private readonly IPrizeService _prizeService;
        public PrizesController(IPrizeService prizeService)
        {
            _prizeService = prizeService;
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("add")]
        public async Task<ResponseResult> Add(PrizeViewModel model)
        {
            var result = await _prizeService.Add(model);
            if (result == 0)
            {
                return new ResponseResult(400, "Add faild !");
            }
            return new ResponseResult(200, "Add success ");
        }
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_prizeService.GetAll());
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _prizeService.GetById(id);
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [HttpPut]
        [Route("update")]
        public async Task<ResponseResult> Update(PrizeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseResult(500, "Model incorrect !");
            }
            var result = await _prizeService.Update(model);
            if(result == 0)
            {
                return new ResponseResult(400, "Update faild !");
            }
            return new ResponseResult(200, "Update success !");
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ResponseResult> Delete(string id)
        {
            var result = await _prizeService.Delete(id);
            if(result == 0)
            {
                return new ResponseResult(400, "Delete faild !");
            }
            return new ResponseResult(200, "Delete success");
        }
        [HttpGet]
        [Route("get-by-event-id/{eventId}")]
        public async Task<IActionResult> GetByEventId(string eventId)
        {
            var result = await _prizeService.GetByEventId(eventId);
            return Ok(result);
        }

    }
}
