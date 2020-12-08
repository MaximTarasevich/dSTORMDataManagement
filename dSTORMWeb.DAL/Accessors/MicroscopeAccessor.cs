using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace dSTORMWeb.DAL.Accessors
{
    public class MicroscopeAccessor : BaseAccessor<Microscope>
    {
        public MicroscopeAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<MicroscopeEntity> GetMicroscope(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToMicroscopeEntity();
        }

        public async Task<MicroscopeEntity> GetMicroscope(string producer, string model , string type)
        {

            return (await Query.Where(e => e.Producer == producer && e.Model == model && e.Type == type).FirstOrDefaultAsync()).ToMicroscopeEntity();
        }

        public async Task<MicroscopeEntity> SaveMicroscope(MicroscopeEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToMicroscope(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToMicroscope(_item)));
            }
            return await GetMicroscope(_item.Id);
        }

        public async Task<List<MicroscopeEntity>> GetMicroscopes(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<Microscope> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToMicroscopeEntityCollection().ToList();
        }

        public async Task<int> GetMicroscopesCount()
        {
            return await Query.CountAsync();
        }
        public async Task<int> DeleteMicroscopeItem(int id)
        {
            var res = await Context.Database.ExecuteSqlCommandAsync("delete from microscopes where Id = " + id + "");
            return await Context.SaveChangesAsync();
        }
    }
}
