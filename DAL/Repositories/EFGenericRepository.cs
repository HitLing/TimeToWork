using BLL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal TimeToWorkContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(TimeToWorkContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetList()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity? GetByIdOrNULL(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual bool Delete(object id)
        {
            var entityToDelete = _dbSet.Find(id);

            if(entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
