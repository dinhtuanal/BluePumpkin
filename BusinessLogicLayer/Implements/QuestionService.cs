using BusinessLogicLayer.Interfaces;
using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using SharedObjects.Commons;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Implements
{
    public class QuestionService : IQuestionService
    {
        private readonly BluePumpkinDbContext _context;

        public QuestionService(BluePumpkinDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(QuestionViewModel model)
        {
            var questions = new Question
            {
                QuestionId = Guid.NewGuid(),
                Title = model.Title,
                Answer = model.Answer,
                CreatedBy = model.CreatedBy
            };
            _context.Questions.Add(questions);
            return _context.SaveChanges();
        }

        public async Task<int> Delete(string id)
        {
            var question = await _context.Questions.FindAsync(Guid.Parse(id));
            _context.Questions.Remove(question);
            return await _context.SaveChangesAsync();
        }

        public List<VQuestion> GetAll()
        {
            var questions = _context.Questions.ToList();
            var vQuestions = questions.ConvertAll(x => new VQuestion
            {
                QuestionId = x.QuestionId,
                Title = x.Title,
                Answer = x.Answer,
                CreatedBy = x.CreatedBy
            });
            return vQuestions;
        }

        public async Task<VQuestion> GetById(string id)
        {
            var question = await _context.Questions.FindAsync(Guid.Parse(id));
            if (question == null)
            {

            }
            var vQuestion = new VQuestion
            {
                QuestionId = question.QuestionId,
                Title = question.Title,
                Answer = question.Answer,
                CreatedBy = question.CreatedBy
            };
            return vQuestion;
        }

        public async Task<int> Update(QuestionViewModel model)
        {
            var question = await _context.Questions.FindAsync(Guid.Parse(model.QuestionId));
            if (question == null)
            {
                throw new CustomException("Can not find question id !", 404);
            }
            question.Title = model.Title;
            question.Answer = model.Answer;
            question.CreatedBy = model.CreatedBy;
            _context.Questions.Update(question);
            return await _context.SaveChangesAsync();
        }
    }
}
