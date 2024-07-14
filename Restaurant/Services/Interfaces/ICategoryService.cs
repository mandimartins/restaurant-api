using Restaurant.Data.ViewModel;
using Restaurant.Data.Models;

namespace Restaurant.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetAsyncAsNoTracking(int id);
        Task<Category> AddAsync(CategoryViewModel category);
        Task<Category> UpdateAsync(CategoryViewModel category);
        Task<Category> DeleteAsync(CategoryViewModel category);
    }
}
