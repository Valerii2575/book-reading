using AutoMapper;
using BookReading.API.Dtos.Category;
using BookReading.DomainLayer.Interfaces;
using BookReading.DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReading.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : MainController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryResult = _mapper.Map<IEnumerable<CategoryResultDto>>(categories);

            return Ok(categoryResult);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            var categoryResult = _mapper.Map<CategoryResultDto>(category);

            return Ok(categoryResult);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(CategoryAddDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = _mapper.Map<Category>(categoryDto);
            var result = await _categoryService.AddAsync(category);
            if (result is null)
                return BadRequest();

            var categoryResult = _mapper.Map<CategoryResultDto>(result);
            return Ok(categoryResult);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, CategoryEditDto categoryEditDto)
        {
            if (categoryEditDto.Id != id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var category = _mapper.Map<Category>(categoryEditDto);
            await _categoryService.UpdateAsync(category);

            return Ok(categoryEditDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category is null)
                return NotFound();

            var result = await _categoryService.DeleteAsync(category);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [Route("search/{category}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Category>>> Search(string category)
        {
            var categoryResult = await _categoryService.SearchAsync(category);
            var categories = _mapper.Map<List<Category>>(categoryResult);

            if (categories == null && !categories.Any())
                return BadRequest();

            return Ok(categories);  
        }
    }
}
