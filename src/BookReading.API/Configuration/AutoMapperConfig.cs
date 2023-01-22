using AutoMapper;
using BookReading.API.Dtos.Book;
using BookReading.API.Dtos.Category;
using BookReading.DomainLayer.Models;

namespace BookReading.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
            CreateMap<Category, CategoryResultDto>().ReverseMap();

            CreateMap<Book, BookAddDto>().ReverseMap();
            CreateMap<Book, BookEditDto>().ReverseMap();
            CreateMap<Book, BookResultDto>().ReverseMap();
        }
    }
}
