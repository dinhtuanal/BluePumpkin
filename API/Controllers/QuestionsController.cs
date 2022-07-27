using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_questionService.GetAll());
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _questionService.GetById(id));
        }
        [HttpPost]
        [Route("add")]
        public async Task<ResponseResult> Add(QuestionViewModel model)
        {
            var result = await _questionService.Add(model);
            if (result == 0)
            {
                return new ResponseResult(400, "Add failed");
            }
            return new ResponseResult(200, "Add success");
        }
        [HttpPut]
        [Route("update")]
        public async Task<ResponseResult> Update(QuestionViewModel model)
        {
            var result = await _questionService.Update(model);
            if (result == 0)
            {
                return new ResponseResult(400, "Update failed");
            }
            return new ResponseResult(200, "Update success");
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ResponseResult> Delete(string id)
        {
            var result = await _questionService.Delete(id);
            if (result == 0)
            {
                return new ResponseResult(400, "Delete failed");
            }
            return new ResponseResult(200, "Delete success");
        }
    }
}
