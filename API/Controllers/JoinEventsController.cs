using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinEventsController : ControllerBase
    {
        private readonly IJoinEventService _joinEventService;
        public JoinEventsController(IJoinEventService joinEventService)
        {
            _joinEventService = joinEventService;
        }
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_joinEventService.GetAll());
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _joinEventService.GetById(id));
        }
        [HttpPost]
        [Route("add")]
        public async Task<ResponseResult> Add(JoinEventViewModel model)
        {
            model.JoinEventStatus = 2;
            var result = await _joinEventService.Add(model);
            if (result == 0)
            {
                return new ResponseResult(400, "Add join event failed !");
            }
            return new ResponseResult(200, "Add join event success");
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ResponseResult> Delete(string id)
        {
            var result = await _joinEventService.Delete(id);
            if (result == 0)
            {
                return new ResponseResult(400, "Delete failed !");
            }
            return new ResponseResult(200, "Delete success");
        }
        [HttpPut]
        [Route("update")]
        public async Task<ResponseResult> Update(JoinEventViewModel model)
        {
            var result = await _joinEventService.Update(model);
            if (result == 0)
            {
                return new ResponseResult(400, "Update failed !");
            }
            return new ResponseResult(200, "Update success");
        }
    }
}
