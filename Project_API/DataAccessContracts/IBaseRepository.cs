namespace Application.DataAccessContracts
{
  public interface IBaseRepository<TEntity>
  {
    IEnumerable<TEntity> GetAll();
    TEntity Get(int id);

    void Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);

    void Save();
  }
}
