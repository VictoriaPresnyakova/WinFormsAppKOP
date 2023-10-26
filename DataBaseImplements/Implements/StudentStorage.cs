using DataBaseImplements.Models;
using StudentContracts.BindingModels;
using StudentContracts.StorageContracts;
using StudentContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseImplements.Implements
{
    public class StudentStorage : IStudentStorage
    {
        public void Delete(StudentBindingModel model)
        {
            var context = new Database();
            var student = context.Students.FirstOrDefault(rec => rec.Id == model.Id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Студент не найден");
            }
        }

        public StudentViewModel GetElement(StudentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new Database();
            var student = context.Students
                    .ToList()
                    .FirstOrDefault(rec => rec.Id == model.Id);
            return student != null ? CreateModel(student) : null;
        }

        public List<StudentViewModel> GetFilteredList(StudentBindingModel model)
        {
            var context = new Database();
            return context.Students
                .Where(student => student.Name.Contains(model.Name))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public List<StudentViewModel> GetFullList()
        {
            using (var context = new Database())
            {
                return context.Students
                .ToList()
                .Select(CreateModel)
                .ToList();
            }
        }

        public void Insert(StudentBindingModel model)
        {
            var context = new Database();
            var transaction = context.Database.BeginTransaction();
            try
            {
                context.Students.Add(CreateModel(model, new Student()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(StudentBindingModel model)
        {
            var context = new Database();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var student = context.Students.FirstOrDefault(rec => rec.Id == model.Id);
                if (student == null)
                {
                    throw new Exception("Студент не найден");
                }
                CreateModel(model, student);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private static Student CreateModel(StudentBindingModel model, Student student)
        {
            student.Name = model.Name;
            student.Av_Score = model.Av_Score.ToString();
            student.Education_Form = model.Education_Form;
            student.Date = model.Date;

            return student;
        }

        private StudentViewModel CreateModel(Student student)
        {
            string[] tempArray = student.Av_Score.Split(' ');

            List<float> temps = new List<float>();
            foreach (string temp in tempArray)
                temps.Add(float.Parse(temp));

            return new StudentViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Av_Score = temps,
                Education_Form = student.Education_Form,
                Date = student.Date,

            };
        }
    }
}
