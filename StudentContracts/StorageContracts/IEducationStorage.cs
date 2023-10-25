using StudentContracts.BindingModels;
using StudentContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentContracts.StorageContracts
{
    public interface IEducationStorage
    {
        List<EducationViewModel> GetFullList();
        List<EducationViewModel> GetFilteredList(EducationBindingModel model);
        EducationViewModel GetElement(EducationBindingModel model);

        void Insert(EducationBindingModel model);
        void Update(EducationBindingModel model);
        void Delete(EducationBindingModel model);
    }
}
}
