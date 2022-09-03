using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestion _question;

        public QuestionController(IQuestion question)
        {
            this._question = question;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _question.getQuestions();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var result = await _question.getQuestion(id);
            return View(result);
        }
    }
}
