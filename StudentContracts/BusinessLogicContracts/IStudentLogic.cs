using StudentContracts.BindingModels;
using StudentContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentContracts.BusinessLogicContracts
{
    public interface IStudentLogic
    {
        List<StudentViewModel> Read(StudentBindingModel model);
        void CreateOrUpdate(StudentBindingModel model);
        void Delete(StudentBindingModel model);
        string[] GetYears();
        double[] GetStudentCountByYear(string Education_Form);
    }
}
