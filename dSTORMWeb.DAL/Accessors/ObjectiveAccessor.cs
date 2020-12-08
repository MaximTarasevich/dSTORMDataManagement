using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace dSTORMWeb.DAL.Accessors
{
    public class ObjectiveAccessor : BaseAccessor<Objective>
    {
        public ObjectiveAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<ObjectiveEntity> GetObjective(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToObjectiveEntity();
        }

        public async Task<ObjectiveEntity> SaveObjective(ObjectiveEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToObjective(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToObjective(_item)));
            }
            return await GetObjective(_item.Id);
        }

        public async Task<List<ObjectiveEntity>> GetObjectives(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<Objective> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToObjectiveEntityCollection().ToList();
        }

        public async Task<int> GetObjectivesCount()
        {
            return await Query.CountAsync();
        }

        public async Task<int> DeleteItem(int id)
        {
            var res = await Context.Database.ExecuteSqlCommandAsync("delete from objectives where Id = " + id + "");
            return await Context.SaveChangesAsync();
        }
    }
}
