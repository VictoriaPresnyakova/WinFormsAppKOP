using StudentContracts.BindingModels;
using StudentContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentContracts.BusinessLogicContracts
{
    public interface IEducationLogic
    {
        List<EducationViewModel> Read(EducationBindingModel model);
        void CreateOrUpdate(EducationBindingModel model);
        void Delete(EducationBindingModel model);
    }
}
