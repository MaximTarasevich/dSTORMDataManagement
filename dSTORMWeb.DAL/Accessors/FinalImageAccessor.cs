using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Converters;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace dSTORMWeb.DAL.Accessors
{
    public class FinalImageAccessor : BaseAccessor<FinalImage>
    {
        public FinalImageAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<FinalImageEntity> GetFinalImage(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToFinalImageEntity();
        }

        public async Task<FinalImageEntity> SaveFinalImage(FinalImageEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToFinalImage(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToFinalImage(_item)));
            }
            return await GetFinalImage(_item.Id);
        }

        public async Task<List<FinalImageEntity>> GetFinalImages(Dictionary<string, FilterEntity> filters, int skip, int take, string sortfield)
        {
            IQueryable<FinalImage> q = QueryHelper.BuildQuery(Query, filters, sortfield);

            return (await q.Skip(skip).Take(take).ToListAsync()).ToFinalImageEntityCollection().ToList();
        }

        public async Task<int> GetFinalImagesCount()
        {
            return await Query.CountAsync();
        }
    }
}
