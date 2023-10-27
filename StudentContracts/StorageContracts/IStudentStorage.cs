using StudentContracts.BindingModels;
using StudentContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentContracts.StorageContracts
{
    public interface IStudentStorage
    {
        List<StudentViewModel> GetFullList();
        List<StudentViewModel> GetFilteredList(StudentBindingModel model);
        StudentViewModel GetElement(StudentBindingModel model);

        void Insert(StudentBindingModel model);
        void Update(StudentBindingModel model);
        void Delete(StudentBindingModel model);
        string[] GetYears();
        double[] GetStudentCountByYear(string Education_Form);


    }
}
