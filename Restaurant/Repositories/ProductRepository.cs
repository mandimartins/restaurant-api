using Restaurant.Data.Enums.Shared;
using Restaurant.Data.Models;
using Restaurant.Data.ViewModels;
using Restaurant.Data;
using Restaurant.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Data.DTOs;

namespace Restaurant.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetAsyncAsNoTracking(int Id)
        {
            return await _context.Set<Product>()
                 .AsNoTracking()
                 .Where(c => c.Id == Id)
                 .FirstAsync();
        }

        public async Task<(int TotalRows, IList<ProductDTO> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter)
        {
            var query = _context.Set<Product>()
                        .Include(p => p.Category)
                        .Select(p => new ProductDTO
                        {
                            Id = p.Id,
                            Name =p.Name,
                            Description = p.Description,
                            Price = p.Price,
                            ImageUrl = p.ImageUrl,
                            CategoryName = p.Category.Name
                        })
                 .AsNoTracking();

            int id = 0;
            int.TryParse(filter.FilterTerm, out id);

            switch (filter.FilterType)
            {
                case (int)FilterTypeEnum.Code:
                    query = query.Where(c => c.Id == id);
                    break;
                case (int)FilterTypeEnum.Name:
                    query = query.Where(c => c.Name.Contains(filter.FilterTerm));
                    break;
                case (int)FilterTypeEnum.Description:
                    query = query.Where(c => c.Description.Contains(filter.FilterTerm));
                    break;
                default:
                    break;
            }

            var totalRows = await query.CountAsync();

            if (!filter.Sort.IsNullOrEmpty())
            {
                foreach (var item in filter.Sort)
                {

                    if (item.Column.Equals("Id") && item.Direction.Equals("asc"))
                        query = query.OrderBy(c => c.Description);

                    if (item.Column.Equals("Id") && item.Direction.Equals("desc"))
                        query = query.OrderByDescending(c => c.Description);

                    if (item.Column.Equals("Name") && item.Direction.Equals("asc"))
                        query = query.OrderBy(c => c.Description);

                    if (item.Column.Equals("Name") && item.Direction.Equals("desc"))
                        query = query.OrderByDescending(c => c.Description);

                    if (item.Column.Equals("Description") && item.Direction.Equals("asc"))
                        query = query.OrderBy(c => c.Description);

                    if (item.Column.Equals("Description") && item.Direction.Equals("desc"))
                        query = query.OrderByDescending(c => c.Description);

                    if (item.Column.Equals("Category") && item.Direction.Equals("asc"))
                        query = query.OrderBy(c => c.IdCategory);

                    if (item.Column.Equals("Category") && item.Direction.Equals("desc"))
                        query = query.OrderByDescending(c => c.IdCategory);

                }
            }

            var data = await query
                .Skip(filter.Skip)
                .Take(filter.Take)
                .ToListAsync();

            return (totalRows, data);
        }

        public async Task<Product> DeleteAsync(int id)
        {
            var product = await _context.Set<Product>()
                .Where(c => c.Id == id).FirstAsync();

            _context.Set<Product>().Remove(product);

            await _context.SaveChangesAsync();

            return product;
        }
    }
}
