using Restaurant.Data.Models;

namespace Restaurant.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddAsync(Category category);
        Task<Category> GetAsyncAsNoTracking(int Id);
    }
}
