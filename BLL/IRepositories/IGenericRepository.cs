using System.Linq.Expressions;

namespace BLL.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetList();
        TEntity? GetByIdOrNULL(object id);
        void Create(TEntity entity);
        bool Delete(object id);
        void Update(TEntity entityToUpdate);
        void Save();
    }
}
