using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Data;
using Restaurant.Data.Enums.Shared;
using Restaurant.Data.Models;
using Restaurant.Data.ViewModels;
using Restaurant.Repositories.Interfaces;

namespace Restaurant.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuItemRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MenuItem> AddAsync(MenuItem menu)
        {
            _context.Add(menu);
            await _context.SaveChangesAsync();

            return menu;
        }

        public async Task<MenuItem> GetAsyncAsNoTracking(int Id)
        {
            return await _context.Set<MenuItem>()
                 .AsNoTracking()
                 .Where(c => c.Id == Id)
                 .FirstAsync();
        }

        public async Task<(int TotalRows, IList<MenuItem> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter)
        {
            var query = _context.Set<MenuItem>()
                 .AsNoTracking();

            int id = 0;
            int.TryParse(filter.FilterTerm, out id);

            switch (filter.FilterType)
            {
                case (int)FilterTypeEnum.Code:
                    query = query.Where(c => c.Id == id);
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

                    if (item.Column.Equals("Description") && item.Direction.Equals("asc"))
                        query = query.OrderBy(c => c.Description);

                    if (item.Column.Equals("Description") && item.Direction.Equals("desc"))
                        query = query.OrderByDescending(c => c.Description);
                }
            }

            var data = await query
                .Skip(filter.Skip)
                .Take(filter.Take)
                .ToListAsync();

            return (totalRows, data);
        }

        public async Task<MenuItem> DeleteAsync(int id)
        {
            var menu = await _context.Set<MenuItem>()
                .Where(c => c.Id == id).FirstAsync();

            _context.Set<MenuItem>().Remove(menu);

            await _context.SaveChangesAsync();

            return menu;
        }

        public async Task<IList<MenuItem>> GetAllAsyncAsNoTracking()
        {
            return await _context.Set<MenuItem>()
                 .AsNoTracking()
                 .ToListAsync();
        }

        public async Task<IList<MenuItem>> GetAllMenuItensByIdMenuAsNoTracking(int idMenu)
        {
            return await _context.Set<MenuItem>()
                     .Where(x => x.Id == idMenu)
                     .AsNoTracking()
                     .ToListAsync();
        }
    }
}
