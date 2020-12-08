using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace dSTORMWeb.DAL.Accessors
{
    public class PhysicalPropertiesAccessor : BaseAccessor<PhysicalProperty>
    {
        public PhysicalPropertiesAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<PhysicalPropertyEntity> GetPhysicalProperty(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToPhysicalPropertyEntity();
        }

        public async Task<PhysicalPropertyEntity> GetPhysicalProperty(double humidity, double temp)
        {

            return (await Query.Where(e => e.Humidity == humidity && e.Temperature == temp).FirstOrDefaultAsync()).ToPhysicalPropertyEntity();
        }

        public async Task<PhysicalPropertyEntity> SavePhysicalProperty(PhysicalPropertyEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToPhysicalProperty(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToPhysicalProperty(_item)));
            }
            return await GetPhysicalProperty(_item.Id);
        }

        public async Task<List<PhysicalPropertyEntity>> GetPhysicalProperties(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<PhysicalProperty> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToPhysicalPropertyEntityCollection().ToList();
        }

        public async Task<int> GetPhysicalPropertiesCount()
        {
            return await Query.CountAsync();
        }

        public async Task<int> DeletePhysicalPropertyItem(int id)
        {
            var res = await Context.Database.ExecuteSqlCommandAsync("delete from physicalproperties where Id = " + id + "");
            return await Context.SaveChangesAsync();
        }
    }
}
