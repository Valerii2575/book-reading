using System;
namespace BookReading.DomainLayer.Models
{
    public class Category : Entity
    {
        public string? Name { get; set; }

        public IEnumerable<Book>? Books { get; set; }
    }
}

