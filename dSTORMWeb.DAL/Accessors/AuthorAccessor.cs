using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;


namespace dSTORMWeb.DAL.Accessors
{
    public class AuthorAccessor : BaseAccessor<Author>
    {
        public AuthorAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<AuthorEntity> GetAuthor(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToAuthorEntity();
        }

        public async Task<AuthorEntity> SaveAuthor(AuthorEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToAuthor(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToAuthor(_item)));
            }
            return await GetAuthor(_item.Id);
        }

        public async Task<List<AuthorEntity>> GetAuthors(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<Author> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToAuthorEntityCollection().ToList();
        }

        public async Task<int> GetAuthorsCount()
        {
            return await Query.CountAsync();
        }



    }
}
