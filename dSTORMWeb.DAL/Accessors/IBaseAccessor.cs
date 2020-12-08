using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using dSTORMWeb.DAL.Models;

namespace dSTORMWeb.DAL.Accessors
{
    public interface IBaseAccessor<TEntity> where TEntity : class, IBaseModel, new()
    {
        Task<TEntity> SaveEntity(TEntity value);

        Task<TEntity> Remove(TEntity value);

        Task<int> DeleteEntity(int id);

        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
    }
}
