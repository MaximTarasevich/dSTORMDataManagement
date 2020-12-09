using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace dSTORMWeb.DAL.Accessors
{
    public class dSTORMInfoAccessor : BaseAccessor<dSTORMInfo>
    {
        public dSTORMInfoAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<dSTORMInfoEntity> GetdSTORMInfo(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).TodSTORMInfoEntity();
        }
        public async Task<dSTORMInfoEntity> GetdSTORMInfo(double x, double y, int fragId)
        {

            return (await Query.Where(e => e.XCoord == x && e.YCoord == y && e.VideoFragmentId == fragId).FirstOrDefaultAsync()).TodSTORMInfoEntity();
        }
        public async Task<dSTORMInfoEntity> SavedSTORMInfo(dSTORMInfoEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.TodSTORMInfo(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.TodSTORMInfo(_item)));
            }
            return await GetdSTORMInfo(_item.Id);
        }

        public async Task<List<dSTORMInfoEntity>> GetdSTORMInfos(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<dSTORMInfo> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).TodSTORMInfoEntityCollection().ToList();
        }

        public async Task<int> GetdSTORMInfosCount()
        {
            return await Query.CountAsync();
        }
    }
}
