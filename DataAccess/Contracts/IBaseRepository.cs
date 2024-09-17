namespace Application.DataAccessContracts
{
    public interface IBaseRepository<TEntity>
    {
        public IEnumerable<TEntity> GetAll();
        TEntity? GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);

        void Save();
    }
}
