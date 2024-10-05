using Restaurant.Data.DTOs;
using Restaurant.Data.Models;
using Restaurant.Data.ViewModels;

namespace Restaurant.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product category);
        Task<Product> GetAsyncAsNoTracking(int Id);
        Task<(int TotalRows, IList<ProductDTO> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter);
        Task<Product> DeleteAsync(int id);
    }
}
