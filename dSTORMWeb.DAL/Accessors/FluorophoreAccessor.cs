using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace dSTORMWeb.DAL.Accessors
{
    public class FluorophoreAccessor : BaseAccessor<Fluorophore>
    {
        public FluorophoreAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<FluorophoreEntity> GetFluorophore(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToFluorophoreEntity();
        }

        public async Task<FluorophoreEntity> SaveFluorophore(FluorophoreEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToFluorophore(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToFluorophore(_item)));
            }
            return await GetFluorophore(_item.Id);
        }

        public async Task<List<FluorophoreEntity>> GetFluorophores(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<Fluorophore> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToFluorophoreEntityCollection().ToList();
        }

        public async Task<int> GetFluorophoresCount()
        {
            return await Query.CountAsync();
        }
    }
}
