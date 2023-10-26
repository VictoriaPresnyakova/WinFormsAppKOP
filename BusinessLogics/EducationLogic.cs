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
    public class EducationLogic : IEducationLogic
    {
        private readonly IEducationStorage _educationStorage;
        public EducationLogic(IEducationStorage educationStorage)
        {
            _educationStorage = educationStorage;
        }

        public void CreateOrUpdate(EducationBindingModel model)
        {
            var element = _educationStorage.GetElement(
               new EducationBindingModel
               {
                   Name = model.Name
               });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Такая программа уже существует");
            }
            if (model.Id.HasValue)
            {
                _educationStorage.Update(model);
            }
            else
            {
                _educationStorage.Insert(model);
            }
        }

        public void Delete(EducationBindingModel model)
        {
            var element = _educationStorage.GetElement(new EducationBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Программа не найдена");
            }
            _educationStorage.Delete(model);
        }

        public List<EducationViewModel> Read(EducationBindingModel model)
        {
            if (model == null)
            {
                return _educationStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<EducationViewModel> { _educationStorage.GetElement(model) };
            }
            return _educationStorage.GetFilteredList(model);
        }
    }
}
