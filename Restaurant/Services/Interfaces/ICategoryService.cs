using Restaurant.Data.ViewModel;
using Restaurant.Data.Models;
using Restaurant.Data.ViewModels;

namespace Restaurant.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetAsyncAsNoTracking(int id);
        Task<(int totalRows, IList<Category> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter);
        Task<Category> AddAsync(CategoryViewModel category);
        Task<Category> UpdateAsync(CategoryViewModel category);
        Task<Category> DeleteAsync(int id);
    }
}
