namespace NewRepo.IService
{
    public interface ICoreService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(long id);
        Task Insert(T entity);
        Task Update(long id, T entity);
        Task Delete(long id);
    }
}
