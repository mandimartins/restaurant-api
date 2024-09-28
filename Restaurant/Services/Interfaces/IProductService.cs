using Restaurant.Data.DTOs;
using Restaurant.Data.Models;
using Restaurant.Data.ViewModels;

namespace Restaurant.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetAsyncAsNoTracking(int id);
        Task<(int totalRows, IList<ProductDTO> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter);
        Task<Product> AddAsync(ProductViewModel category);
        Task<Product> UpdateAsync(ProductViewModel category);
        Task<Product> DeleteAsync(int id);
    }
}
