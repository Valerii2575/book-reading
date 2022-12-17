using System;
namespace BookReading.DomainLayer.Models
{
    public class Book : Entity
    {
        public string? Name { get; set; }

        public string? Author { get; set; }

        public string? Description { get; set; }

        public double Value { get; set; }

        public DateTime PublishDate { get; set; }

        public Guid CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}

