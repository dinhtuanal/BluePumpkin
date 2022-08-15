using App.Models;
namespace App.Services.Interfaces
{
    public interface IQuestion
    {
        public Task<List<QuestionModel>?> getQuestions();
        public Task<QuestionModel?> getQuestion(string id);
    }
}
