using BookReading.DomainLayer.Models;

namespace BookReading.DomainLayer.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        new Task<List<Book>> GetAllAsync();
        new Task<Book> GetByIdAsync(Guid id);
        Task<IEnumerable<Book>> GetBookByCategoryAsync(Guid categoryId);
        Task<IEnumerable<Book>> SearchBookWhthCategoryAsync(string searchValue);
    }
}
