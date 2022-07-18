using BusinessLogicLayer.Interfaces;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using DataAccessLayer.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Implements
{
    public class TestService : ITestService
    {
        private readonly BluePumpkinDbContext _context;
        public TestService(BluePumpkinDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(TestViewModel model)
        {
            var test = new Test
            {
                TestId = Guid.NewGuid(),
                TestName = model.TestName,
                CreatedAt = DateTime.Now,
            };
            _context.Tests.Add(test);
            return await _context.SaveChangesAsync();
        }

        public Task<int> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public VTest Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<VTest> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(TestViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
