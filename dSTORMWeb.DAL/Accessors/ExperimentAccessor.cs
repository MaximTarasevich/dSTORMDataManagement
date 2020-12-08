using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace dSTORMWeb.DAL.Accessors
{
    public class ExperimentAccessor : BaseAccessor<Experiment>
    {
        public ExperimentAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<ExperimentEntity> GetExperiment(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToExperimentEntity();
        }

        public async Task<ExperimentEntity> SaveExperiment(ExperimentEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToExperiment(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToExperiment(_item)));
            }
            return await GetExperiment(_item.Id);
        }

        public async Task<List<ExperimentEntity>> GetExperiments(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<Experiment> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToExperimentEntityCollection().ToList();
        }

        public async Task<int> GetExperimentsCount()
        {
            return await Query.CountAsync();
        }
    }
}
