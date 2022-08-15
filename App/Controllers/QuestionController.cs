using App.Models;
using App.Services.Implements;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class QuestionController : Controller
    {
        private readonly Question _question;

        public QuestionController(Question question)
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
