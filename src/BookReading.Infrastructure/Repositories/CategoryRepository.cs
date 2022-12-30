using BookReading.DomainLayer.Interfaces;
using BookReading.DomainLayer.Models;
using BookReading.Infrastructure.Context;

namespace BookReading.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookReadingDbContext db) : base(db)
        {
        }
    }
}
