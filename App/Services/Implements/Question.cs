using App.Services.Interfaces;
using App.Services.common;
using App.Models;
using Newtonsoft.Json;

namespace App.Services.Implements
{
    public class Question : BaseClient, IQuestion
    {
        public async Task<QuestionModel?> getQuestion(string id)
        {
            var response = await httpClient.GetAsync("api/Questions/get/" + id);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<QuestionModel>(result);
        }

        public async Task<List<QuestionModel>?> getQuestions()
        {
            var response = await httpClient.GetAsync("api/Questions/get-all");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<QuestionModel>>(result);
        }


    }
}
