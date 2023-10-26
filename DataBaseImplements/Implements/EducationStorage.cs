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
    public class EducationStorage : IEducationStorage
    {
        public void Delete(EducationBindingModel model)
        {
            var context = new Database();
            var education = context.Educations.FirstOrDefault(rec => rec.Id == model.Id);
            if (education != null)
            {
                context.Educations.Remove(education);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Направление не найдено");
            }
        }

        public EducationViewModel GetElement(EducationBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new Database();

            var education = context.Educations
                    .ToList()
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
            return education != null ? CreateModel(education) : null;
        }


        public List<EducationViewModel> GetFilteredList(EducationBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new Database();
            return context.Educations
                .Where(rec => rec.Name.Contains(model.Name))
                .Select(CreateModel)
                .ToList();
        }

        public List<EducationViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Educations
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(EducationBindingModel model)
        {
            var context = new Database();
            var transaction = context.Database.BeginTransaction();
            try
            {
                context.Educations.Add(CreateModel(model, new Education()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(EducationBindingModel model)
        {
            var context = new Database();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var education = context.Educations.FirstOrDefault(rec => rec.Id == model.Id);
                if (education == null)
                {
                    throw new Exception("Направление не найдено");
                }
                CreateModel(model, education);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private static Education CreateModel(EducationBindingModel model, Education education)
        {
            education.Name = model.Name;
            return education;
        }

        private static EducationViewModel CreateModel(Education education)
        {
            return new EducationViewModel
            {
                Id = education.Id,
                Name = education.Name
            };
        }
    }
}
