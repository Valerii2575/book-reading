using System.ComponentModel.DataAnnotations;

namespace BookReading.API.Dtos.Category
{
    public class CategoryAddDto
    {
        [Required(ErrorMessage = "This field {0} is required")]
        [StringLength(150, ErrorMessage = "This field must be between {1} and {2}", MinimumLength = 2)]
        public string Name { get; set; }
    }
}
