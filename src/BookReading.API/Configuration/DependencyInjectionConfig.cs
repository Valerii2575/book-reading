using BookReading.DomainLayer.Interfaces;
using BookReading.DomainLayer.Services;
using BookReading.Infrastructure.Context;
using BookReading.Infrastructure.Repositories;

namespace BookReading.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolvedDependencies(this IServiceCollection services)
        {
            services.AddScoped<BookReadingDbContext>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
