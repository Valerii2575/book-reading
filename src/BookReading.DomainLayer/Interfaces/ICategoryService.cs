using BookReading.DomainLayer.Models;

namespace BookReading.DomainLayer.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task<Category> AddAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<bool> DeleteAsync(Category category);
        Task<IEnumerable<Category>> SearchAsync(string categoryName);
    }
}
