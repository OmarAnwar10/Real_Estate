using Microsoft.EntityFrameworkCore;
using Application.DataAccessContracts;
using application.DataAccess;

namespace API_Project.DataAccess.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _db;
        protected readonly DbSet<TEntity> _dbSet;
        public BaseRepository(AppDbContext context)
        {
            _db = context;
            _dbSet = _db.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }
            _dbSet.Remove(entity);
        }

        public void Save()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // سجل الخطأ
                throw new Exception("An error occurred while saving changes to the database.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("An invalid operation was attempted.", ex);
            }
        }

    }
}
