using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
namespace dSTORMWeb.DAL.Converters
{
    public static class AuthorConverter
    {
        public static Author ToAuthor(this AuthorEntity newEntity, Author oldEntity = null)
        {
            Author entity = oldEntity;
            if (entity == null)
            {
                entity = new Author();

            }

            entity.FirstName = newEntity.FirstName;
            entity.MiddleName = newEntity.MiddleName;
            entity.LastName = newEntity.LastName;
            entity.AcademicRank = newEntity.AcademicRank;
            entity.BirthdayDate = newEntity.BirthdayDate;
            return entity;
        }


        public static AuthorEntity ToAuthorEntity(this Author model)
        {
            if (model == null)
                return null;

            AuthorEntity entity = new AuthorEntity();

            entity.Id = model.Id;
            entity.FirstName = model.FirstName;
            entity.MiddleName = model.MiddleName;
            entity.LastName = model.LastName;
            entity.AcademicRank = model.AcademicRank;
            entity.BirthdayDate = model.BirthdayDate;
            return entity;
        }

        public static IEnumerable<AuthorEntity> ToAuthorEntityCollection(this IEnumerable<Author> items)
        {
            List<AuthorEntity> models = new List<AuthorEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToAuthorEntity()));

            return models;
        }
    }
}
