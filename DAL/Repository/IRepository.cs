namespace DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> Get();
        Task<T> Get(int id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);

    }
}
