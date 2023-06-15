using AutoMapper;
using BookRentalApp.Data.Interface;
using EczacibasiHW1.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookRentalApp.Controllers
{
    [Route("categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryRepository repository, IMapper mapper, ILogger<CategoryController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            _repository.Add(category);

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpGet]
        public IActionResult GetAll(int page = 0, int pageSize = 5)
        {
            return Ok(_repository.GetAll(page, pageSize));

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id, bool withBooks = false)
        {
            Category category = _repository.GetById(id, withBooks);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpGet("/name/{name}")]
        public IActionResult GetByName(string name, bool withBooks = false)
        {
            Category category = _repository.GetByName(name, withBooks);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Category category)
        {
            _repository.Update(id, category);

            return Ok(category);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }

    }
}
