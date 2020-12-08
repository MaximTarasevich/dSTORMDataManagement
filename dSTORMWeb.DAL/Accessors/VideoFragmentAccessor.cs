using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace dSTORMWeb.DAL.Accessors
{
    public class VideoFragmentAccessor : BaseAccessor<VideoFragment>
    {
        public VideoFragmentAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<VideoFragmentEntity> GetVideoFragment(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToVideoFragmentEntity();
        }

        public async Task<VideoFragmentEntity> SaveVideoFragment(VideoFragmentEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToVideoFragment(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToVideoFragment(_item)));
            }
            return await GetVideoFragment(_item.Id);
        }

        public async Task<List<VideoFragmentEntity>> GetVideoFragments(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<VideoFragment> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToVideoFragmentEntityCollection().ToList();
        }

        public async Task<int> GetVideoFragmentCount()
        {
            return await Query.CountAsync();
        }
    }
}
