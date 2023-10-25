using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentContracts.ViewModels
{
    public class StudentViewModel
    {
        public int? Id { get; set; }

        [DisplayName("ФИО")]
        public string Name { get; set; }

        [DisplayName("Средний балл")]
        public Dictionary<string, float> Av_Score { get; set; }

        [DisplayName("Форма обучения")]
        public string Education_Form { get; set; }

        [DisplayName("Дата поступления")]
        public DateTime Date { get; set; }
    }
}
