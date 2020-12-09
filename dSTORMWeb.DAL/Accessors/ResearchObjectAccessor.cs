using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace dSTORMWeb.DAL.Accessors
{
    public class ResearchObjectAccessor: BaseAccessor<ResearchObject>
    {

        public ResearchObjectAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<ResearchObjectEntity> GetResearchObject(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToResearchObjectEntity();
        }
        public async Task<ResearchObjectEntity> GetResearchObject(string name)
        {

            return (await Query.Where(e => e.Name == name).FirstOrDefaultAsync()).ToResearchObjectEntity();
        }
        public async Task<ResearchObjectEntity> SaveResearchObject(ResearchObjectEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToResearchObject(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToResearchObject(_item)));
            }
            return await GetResearchObject(_item.Id);
        }

        public async Task<List<ResearchObjectEntity>> GetResearchObjects(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<ResearchObject> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToResearchObjectEntityCollection().ToList();
        }

        public async Task<int> GetResearchObjectsCount()
        {
            return await Query.CountAsync();
        }
    }
}
