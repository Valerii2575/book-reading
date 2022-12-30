using BookReading.DomainLayer.Interfaces;
using BookReading.DomainLayer.Models;

namespace BookReading.DomainLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> AddAsync(Book book)
        {
            if (_bookRepository.SearchAsync(x => x.Name == book.Name).Result.Any())
                return null;

            await _bookRepository.AddAsync(book);

            return book;
        }

        public async Task<bool> DeleteAsync(Book book)
        {
            await _bookRepository.DeleteAsync(book);
            return true;
        }

        public void Dispose()
        {
            _bookRepository.Dispose();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public Task<IEnumerable<Book>> GetBookByCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> GetById(Guid id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Book>> SearchAsync(string bookName)
        {
            return await _bookRepository.SearchAsync(x => x.Name == bookName);
        }

        public async Task<IEnumerable<Book>> SearchBookWithCategoryAsync(string searchedValue)
        {
            return await _bookRepository.SearchBookWhthCategoryAsync(searchedValue);
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            if (_bookRepository.SearchAsync(x => x.Name == book.Name && x.Id != book.Id).Result.Any())
                return null;

            await _bookRepository.UpdateAsync(book);

            return book;
        }
    }
}
