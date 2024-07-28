using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.Data.ViewModels;
using Restaurant.Repositories.Interfaces;

namespace Restaurant.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> AddAsync(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> GetAsyncAsNoTracking(int Id)
        {
           return await  _context.Set<Category>()
                .AsNoTracking()
                .Where(c => c.Id == Id)
                .FirstAsync();
        }

        public async Task<(int TotalRows, IList<Category> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter)
        {
            var query = _context.Set<Category>()
                 .AsNoTracking();

            var totalRows = await query.CountAsync();

            var data = await query
                .Skip(filter.Skip)
                .Take(filter.Take)
                .ToListAsync();

            return (totalRows, data);
        }

        public async Task<Category> DeleteAsync(int id)
        {
            var category = await _context.Set<Category>()
                .Where(c => c.Id == id).FirstAsync();

            _context.Set<Category>().Remove(category);

            await _context.SaveChangesAsync();

            return category;
        }
    }
}
