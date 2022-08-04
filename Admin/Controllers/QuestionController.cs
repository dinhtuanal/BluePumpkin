using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace Admin.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionClient _questionClient;
        public QuestionController(IQuestionClient questionClient)
        {
            _questionClient = questionClient;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _questionClient.GetAll());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(QuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var token = User.GetSpecificClaim("token");
            var result = await _questionClient.Add(model, token);
            if(result.StatusCode == 200)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Update(string id)
        {
            var question = await _questionClient.GetId(id);
            if(question == null)
            {
                return RedirectToAction("index");
            }
            QuestionViewModel model = new QuestionViewModel
            {
                QuestionId = question.QuestionId.ToString(),
                Title = question.Title,
                Answer = question.Answer,
                CreatedBy = question.CreatedBy,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(QuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var token = User.GetSpecificClaim("token");
            var result = await _questionClient.Update(model, token);
            if(result.StatusCode == 200)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
