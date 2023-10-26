﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentContracts.BindingModels
{
    public class StudentBindingModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public Dictionary<string, float> Av_Score { get; set; }

        public string Education_Form { get; set; }

        public DateTime Date { get; set; }
    }
}