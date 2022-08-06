using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpPost]
        public async Task<ResponseResult> Add(TestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseResult(400, "Invalid model");
            };
            await _testService.Add(model);
            return new ResponseResult(200, "Add Success");
            
        }
        [HttpGet]
        public IActionResult Test()
        {
            var a = 0;
            var b = 5 / a;
            return Ok("hello");

        }
    }
}
