using BookReading.DomainLayer.Interfaces;
using BookReading.DomainLayer.Models;

namespace BookReading.DomainLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookService _bookService;

        public CategoryService(ICategoryRepository categoryRepository, IBookService bookService)
        {
            _categoryRepository = categoryRepository;
            _bookService = bookService;
        }

        public async Task<Category> AddAsync(Category category)
        {
            if(_categoryRepository.SearchAsync(c => c.Name == category.Name).Result.Any()) {
                return null;
            }

            await _categoryRepository.AddAsync(category);

            return category;
        }

        public async Task<bool> DeleteAsync(Category category)
        {
            var books = await _bookService.GetBookByCategoryAsync(category.Id);
            if (books.Any())
                return false;

            await _categoryRepository.DeleteAsync(category);
            return true;
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Category>> SearchAsync(string categoryName)
        {
            return await _categoryRepository.SearchAsync(c => c.Name.Contains(categoryName));
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            if (_categoryRepository.SearchAsync(c => c.Name == category.Name).Result.Any())
            {
                return null;
            }

            await _categoryRepository.UpdateAsync(category);

            return category;
        }
    }
}
