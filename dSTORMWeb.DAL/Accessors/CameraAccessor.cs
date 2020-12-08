using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace dSTORMWeb.DAL.Accessors
{
    public class CameraAccessor : BaseAccessor<Camera>
    {
        public CameraAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<CameraEntity> GetCamera(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToCameraEntity();
        }

        public async Task<CameraEntity> SaveCamera(CameraEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToCamera(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToCamera(_item)));
            }
            return await GetCamera(_item.Id);
        }

        public async Task<List<CameraEntity>> GetCameras(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<Camera> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToCameraEntityCollection().ToList();
        }

        public async Task<int> GetCamerasCount()
        {
            return await Query.CountAsync();
        }
    }
}
