using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentContracts.ViewModels
{
    public class EducationViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }
    }
}
