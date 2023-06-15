using AutoMapper;
using BookRentalApp.Data.Interface;
using EczacibasiHW1.Models.Entity;
using EczacibasiHW2.Models;
using System.Collections.Generic;
using System.Linq;

namespace EczacibasiHW1.Models.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CommerceContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(CommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Customer Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer Update(int id, Customer customer)
        {
            var updatedCustomer = _context.Customers.FirstOrDefault(x => x.Id == id);
            var tempCustomer = _mapper.Map<Customer>(customer);

            if (!string.IsNullOrEmpty(customer.FirstName))
                updatedCustomer.FirstName = tempCustomer.FirstName;

            if (!string.IsNullOrEmpty(customer.LastName))
                updatedCustomer.LastName = tempCustomer.LastName;

            if (!string.IsNullOrEmpty(customer.Address))
                updatedCustomer.Address = tempCustomer.Address;

            if (!string.IsNullOrEmpty(customer.Email))
                updatedCustomer.Email = tempCustomer.Email;

            if (!string.IsNullOrEmpty(customer.Phone))
                updatedCustomer.Phone = tempCustomer.Phone;

            _context.SaveChanges();
            return updatedCustomer;
        }


        public List<Customer> GetAll(int page = 0, int pageSize = 5)
        {
            return _context.Customers.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public Customer GetById(int id)
        {
            var query = _context.Customers.AsQueryable();
            var customer = query.FirstOrDefault(x => x.Id == id);
            return customer;
        }

        public List<Customer> GetByFirstName(string firstName)
        {
            var query = _context.Customers.AsQueryable();

            query = query.Where(x => x.FirstName == firstName);

            return query.ToList();
        }

        public Customer GetByPhone(string phone)
        {
            var query = _context.Customers.AsQueryable();
            if (phone != null)
            {
                var category = query.FirstOrDefault(x => x.Phone.ToLower().Equals(phone.ToLower()));
                return category;

            }
            return query.FirstOrDefault(x => x.Phone == phone);
        }

        public Customer GetByEmail(string email)
        {
            var query = _context.Customers.AsQueryable();
            if (email != null)
            {
                var category = query.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));
                return category;

            }
            return query.FirstOrDefault(x => x.Email == email);
        }
    }
}
