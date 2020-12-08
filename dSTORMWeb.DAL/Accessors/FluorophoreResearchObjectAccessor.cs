using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace dSTORMWeb.DAL.Accessors
{
    public class FluorophoreResearchObjectAccessor : BaseAccessor<FluorophoreResearchObject>
    {
        public FluorophoreResearchObjectAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<FluorophoreResearchObjectEntity> GetFluorophoreResearchObject(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToFluorophoreResearchObjectEntity();
        }

        public async Task<FluorophoreResearchObjectEntity> SaveFluorophoreResearchObject(FluorophoreResearchObjectEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToFluorophoreResearchObject(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToFluorophoreResearchObject(_item)));
            }
            return await GetFluorophoreResearchObject(_item.Id);
        }

        public async Task<List<FluorophoreResearchObjectEntity>> GetFluorophoreResearchObjects(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<FluorophoreResearchObject> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToFluorophoreResearchObjectEntityCollection().ToList();
        }

        public async Task<int> GetFluorophoreResearchObjectsCount()
        {
            return await Query.CountAsync();
        }
    }
}
