using BookReading.DomainLayer.Interfaces;
using BookReading.DomainLayer.Models;
using BookReading.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookReading.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookReadingDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Book>> GetBookByCategoryAsync(Guid categoryId)
        {
            return await SearchAsync(x => x.CategoryId == categoryId);
        }

        public async Task<IEnumerable<Book>> SearchBookWhthCategoryAsync(string searchValue)
        {
            return await Db.Books.AsNoTracking()
                .Include(c => c.Category)
                .Where(c => c.Name.Contains(searchValue) ||
                        c.Author.Contains(searchValue) ||
                        c.Description.Contains(searchValue) ||
                        c.Category.Name.Contains(searchValue))
                .ToListAsync();
        }

        public override async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await Db.Books.AsNoTracking().Include(b => b.Category)
                .OrderBy(b => b.Name)
                .ToListAsync();
        }
    }
}
