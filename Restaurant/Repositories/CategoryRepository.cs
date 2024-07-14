using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Models;
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
    }
}
