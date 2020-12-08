using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace dSTORMWeb.DAL.Accessors
{
    public class SetupAccessor : BaseAccessor<Setup>
    {
        public SetupAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<SetupEntity> GetSetup(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToSetupEntity();
        }

        public async Task<SetupEntity> SaveSetup(SetupEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToSetup(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToSetup(_item)));
            }
            return await GetSetup(_item.Id);
        }

        public async Task<List<SetupEntity>> GetSetups(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<Setup> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToSetupEntityCollection().ToList();
        }

        public async Task<int> GetSetupsCount()
        {
            return await Query.CountAsync();
        }
    }
}
