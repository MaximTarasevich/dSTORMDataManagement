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


            return entity;
        }


        public static AuthorEntity ToAuthorEntity(this Author model)
        {
            if (model == null)
                return null;

            AuthorEntity entity = new AuthorEntity();

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
