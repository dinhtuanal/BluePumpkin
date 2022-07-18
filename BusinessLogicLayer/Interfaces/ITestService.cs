using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ITestService
    {
        List<VTest> GetAll();
        VTest Get(string id);
        Task<int> Add(TestViewModel model);
        Task<int> Update(TestViewModel model);
        Task<int> Delete(string id);
    }
}
