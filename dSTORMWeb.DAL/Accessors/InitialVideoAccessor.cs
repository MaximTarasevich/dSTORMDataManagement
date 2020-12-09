using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace dSTORMWeb.DAL.Accessors
{
    public class InitialVideoAccessor : BaseAccessor<InitialVideo>
    {
        public InitialVideoAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<InitialVideoEntity> GetInitialVideo(int id)
        {

            return (await Query.Include(e => e.Author).Where(e => e.Id == id).FirstOrDefaultAsync()).ToInitialVideoEntity();
        }

        public async Task<InitialVideoEntity> SaveInitialVideo(InitialVideoEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToInitialVideo(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToInitialVideo(_item)));
            }
            return await GetInitialVideo(_item.Id);
        }

        public async Task<List<InitialVideoEntity>> GetInitialVideos(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<InitialVideo> q = QueryHelper.BuildQuery(Query.Include(e => e.Author), filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToInitialVideoEntityCollection().ToList();
        }

        public async Task<int> GetInitialVideosCount()
        {
            return await Query.CountAsync();
        }
    }
}
