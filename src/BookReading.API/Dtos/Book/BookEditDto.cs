using System.ComponentModel.DataAnnotations;

namespace BookReading.API.Dtos.Book
{
    public class BookEditDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "This field {0} is required")]
        [StringLength(150, ErrorMessage = "This field must be between {1} and {2}", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field {0} is required")]
        [StringLength(150, ErrorMessage = "This field must be between {1} and {2}", MinimumLength = 2)]
        public string Author { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
