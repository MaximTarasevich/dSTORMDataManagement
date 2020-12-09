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

            return (await Query.Include(e => e.AOTFilter).Include(e => e.Camera).Include(e => e.Objective).Include(e => e.Laser).Include(e => e.Microscope).Where(e => e.Id == id).FirstOrDefaultAsync()).ToSetupEntity();
        }
        public async Task<SetupEntity> GetSetup(int filterId, int cameraId, int laserId, int microscopeId,int objectiveId)
        {

            return (await Query.Where(e => e.AOTFilterId == filterId && e.CameraId == cameraId && e.LaserId == laserId && e.MicroscopeId == microscopeId && e.ObjectiveId == objectiveId).FirstOrDefaultAsync()).ToSetupEntity();
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
            IQueryable<Setup> q = QueryHelper.BuildQuery(Query.Include(e => e.AOTFilter).Include(e => e.Camera).Include(e => e.Objective).Include(e => e.Laser).Include(e => e.Microscope), filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToSetupEntityCollection().ToList();
        }

        public async Task<int> GetSetupsCount()
        {
            return await Query.CountAsync();
        }
    }
}
