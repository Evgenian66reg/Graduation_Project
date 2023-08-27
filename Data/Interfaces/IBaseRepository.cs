namespace AgricultDetailMarket.Data.Interfaces
{
    public interface IBaseRepository<T>
    {

       public Task Create(T entity);

       public Task Delete(T entity);

       public Task<T> Update(T entity);

       public IQueryable<T> GetAll();

    }
}
