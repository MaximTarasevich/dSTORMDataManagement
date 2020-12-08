using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace dSTORMWeb.DAL.Accessors
{
    public class AOTFilterAccessor : BaseAccessor<AOTFilter>
    {
        public AOTFilterAccessor(RepositoryContext db): base(db)
        {
        }

        public async Task<AOTFilterEntity> GetAOTFilter(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToAOTFilterEntity();
        }

        public async Task<AOTFilterEntity> SaveAOTFilter(AOTFilterEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToAOTFilter(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToAOTFilter(_item)));
            }
            return await GetAOTFilter(_item.Id);
        }

        public async Task<List<AOTFilterEntity>> GetAOTFilters(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<AOTFilter> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToAOTFilterEntityCollection().ToList();
        }

        public async Task<int> GetAOTFiltersCount()
        {
            return await Query.CountAsync();
        }


    }
}
