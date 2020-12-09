using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.Server.Models;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.Server.Converters
{
    public static class AuthorConverter
    {
        public static AuthorViewModel ToAuthorViewModel(this AuthorEntity entity)
        {
            AuthorViewModel model = new AuthorViewModel();
            model.Id = entity.Id;
            model.AcademicRank = entity.AcademicRank;
            model.FirstName = entity.FirstName;
            model.MiddleName = entity.MiddleName;
            model.LastName = entity.LastName;
            model.BirthdayDate = entity.BirthdayDate;


            model.FullName = model.FirstName + " " + model.LastName + " " + model.MiddleName + ", BirhdayDate: " + model.BirthdayDate.ToString("dd.MM.yyyy");
            return model;
        }
        public static AuthorEntity ToAuthorEntity(this AuthorViewModel model)
        {
            AuthorEntity entity = new AuthorEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;

            }
            entity.AcademicRank = model.AcademicRank;
            entity.FirstName = model.FirstName;
            entity.MiddleName = model.MiddleName;
            entity.LastName = model.LastName;
            entity.BirthdayDate = model.BirthdayDate;
            return entity;
        }

        public static IEnumerable<AuthorViewModel> ToAuthorViewModelCollection(this IEnumerable<AuthorEntity> items)
        {
            List<AuthorViewModel> models = new List<AuthorViewModel>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToAuthorViewModel()));

            return models;
        }
    }
}
