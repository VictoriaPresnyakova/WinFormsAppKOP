using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseImplements.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Av_Score { get; set; }
        [Required]
        public string Education_Form { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
