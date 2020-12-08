using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace dSTORMWeb.DAL.Accessors
{
    public class LaserAccessor : BaseAccessor<Laser>
    {
        public LaserAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<LaserEntity> GetLaser(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToLaserEntity();
        }
        public async Task<LaserEntity> GetLaser(string producer, string model, string type)
        {

            return (await Query.Where(e => e.Producer == producer && e.Model == model && e.Type == type).FirstOrDefaultAsync()).ToLaserEntity();
        }
        public async Task<LaserEntity> SaveLaser(LaserEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToLaser(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToLaser(_item)));
            }
            return await GetLaser(_item.Id);
        }

        public async Task<List<LaserEntity>> GetLasers(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<Laser> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToLaserEntityCollection().ToList();
        }

        public async Task<int> GetLaserCount()
        {
            return await Query.CountAsync();
        }
        public async Task<int> DeleteLaser(int id)
        {
            var res = await Context.Database.ExecuteSqlCommandAsync("delete from lasers where Id = " + id + "");
            return await Context.SaveChangesAsync();
        }
    }
}
