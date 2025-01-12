using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Data;
using Restaurant.Data.Enums.Shared;
using Restaurant.Data.Models;
using Restaurant.Data.ViewModels;
using Restaurant.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Restaurant.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Menu> AddAsync(Menu menu)
        {
            _context.Add(menu);
            await _context.SaveChangesAsync();

            return menu;
        }

        public async Task<Menu> GetAsyncAsNoTracking(int Id)
        {
           return await  _context.Set<Menu>()
                .AsNoTracking()
                .Where(c => c.Id == Id)
                .FirstAsync();
        }

        public async Task<(int TotalRows, IList<Menu> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter)
        {
            var query = _context.Set<Menu>()
                 .AsNoTracking();

            int id = 0;
            int.TryParse(filter.FilterTerm, out id);

            switch (filter.FilterType)
            {
                case (int)FilterTypeEnum.Code:
                    query = query.Where(c => c.Id == id);
                    break;
                case (int)FilterTypeEnum.Title:
                    query = query.Where(c => c.Title.Contains(filter.FilterTerm));
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

                    if (item.Column.Equals("Title") && item.Direction.Equals("asc"))
                        query = query.OrderBy(c => c.Description);

                    if (item.Column.Equals("Title") && item.Direction.Equals("desc"))
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

        public async Task<Menu> DeleteAsync(int id)
        {
            var menu = await _context.Set<Menu>()
                .Where(c => c.Id == id).FirstAsync();

            _context.Set<Menu>().Remove(menu);

            await _context.SaveChangesAsync();

            return menu;
        }
    }
}
