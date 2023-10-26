using StudentContracts.BindingModels;
using StudentContracts.BusinessLogicContracts;
using StudentContracts.StorageContracts;
using StudentContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics
{
    public class StudentLogic : IStudentLogic
    {
        private readonly IStudentStorage _studentStorage;
        public StudentLogic(IStudentStorage studentStorage)
        {
            _studentStorage = studentStorage;
        }
        public void CreateOrUpdate(StudentBindingModel model)
        {
            var element = _studentStorage.GetElement(
               new StudentBindingModel
               {
                   Name = model.Name,
                   Av_Score = model.Av_Score,
                   Education_Form = model.Education_Form,
                   Date = model.Date,
               });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Студент с таким именем уже существует");
            }
            if (model.Id.HasValue)
            {
                _studentStorage.Update(model);
            }
            else
            {
                _studentStorage.Insert(model);
            }
        }

        public void Delete(StudentBindingModel model)
        {
            var element = _studentStorage.GetElement(new StudentBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Студент не найден");
            }
            _studentStorage.Delete(model);
        }

        public List<StudentViewModel> Read(StudentBindingModel model)
        {
            if (model == null)
            {
                return _studentStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<StudentViewModel> { _studentStorage.GetElement(model) };
            }
            return _studentStorage.GetFilteredList(model);
        }
    }
}
