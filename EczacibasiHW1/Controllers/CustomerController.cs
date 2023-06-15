using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookRentalApp.Data.Interface;
using EczacibasiHW1.Models.Entity;

namespace BookRentalApp.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerRepository repository, IMapper mapper, ILogger<CustomerController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Customer customer)
        {
            _repository.Add(customer);

            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpGet]
        public IActionResult GetAll(int page = 0, int pageSize = 5)
        {
            return Ok(_repository.GetAll(page, pageSize));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Customer customer = _repository.GetById(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet("/email/{email}")]
        public IActionResult GetById(string email)
        {
            Customer customer = _repository.GetByEmail(email);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet("/phone/{phone}")]
        public IActionResult GetByPhone(string phone)
        {
            Customer customer = _repository.GetByPhone(phone);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Customer customer)
        {
            _repository.Update(id, customer);

            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
