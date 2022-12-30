using BookReading.DomainLayer.Models;

namespace BookReading.DomainLayer.Interfaces
{
    public interface IBookService : IDisposable
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetById(Guid id);
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task<bool> DeleteAsync(Book book);
        Task<IEnumerable<Book>> GetBookByCategoryAsync(Guid categoryId);
        Task<IEnumerable<Book>> SearchAsync(string bookName);
        Task<IEnumerable<Book>> SearchBookWithCategoryAsync(string searchedValue);
    }
}
