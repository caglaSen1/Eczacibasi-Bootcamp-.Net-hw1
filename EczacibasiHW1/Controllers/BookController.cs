using AutoMapper;
using BookRentalApp.Data.Interface;
using EczacibasiHW1.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookRentalApp.Controllers
{
    [Route("books")]
    public class BookController : Controller
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookRepository repository, IMapper mapper, ILogger<BookController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            _repository.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);

        }

        [HttpGet]
        public IActionResult GetAll(int page = 0, int pageSize = 5, string sortBy = "Default")
        {            
            return Ok(_repository.GetAll(page, pageSize, sortBy = "Default"));

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id, bool withCategory = false)
        {
            var book = _repository.GetById(id, withCategory);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("/title/{title}")]
        public IActionResult GetByTitle(string title, bool withCategory = false)
        {
            
            var book = _repository.GetByTitle(title, withCategory);

            if (book == null)
                return NotFound();

            return Ok(book);

        }

        [HttpGet("/ISBN/{ISBN}")]
        public IActionResult GetByISBN(string ISBN, bool withCategory = false)
        {
            var book = _repository.GetByISBN(ISBN, withCategory);

            if (book == null)
                return NotFound();

            return Ok(book);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Book book)
        {
            _repository.Update(id, book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult Search(string title, string author, string publisher, string ISBN,
        int? categoryId, double? minPrice, string categoryName, bool? isAvailable)
        {
            return Ok(_repository.Search(title, author, publisher, ISBN, categoryId, minPrice, categoryName, isAvailable));
        }


    }
}
