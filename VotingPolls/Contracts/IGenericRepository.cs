using VotingPolls.Data;

namespace VotingPolls.Contracts
{
    public interface IGenericRepository<T> where T: class
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(int? id);
        Task UpdateAsync(T entity);
        

    }
}
