using AutoMapper;
using BookRentalApp.Data.Interface;
using EczacibasiHW1.Models.Entity;
using EczacibasiHW2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EczacibasiHW1.Models.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CommerceContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(CommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Category Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }

        public Category Update(int id, Category category)
        {
            var updatedCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
            var tempCategory = _mapper.Map<Category>(category);

            if (!string.IsNullOrEmpty(category.Name))
                updatedCategory.Name = tempCategory.Name;
            if (!string.IsNullOrEmpty(category.Description))
                updatedCategory.Description = tempCategory.Description;

            _context.SaveChanges();
            return updatedCategory;
        }

        public List<Category> GetAll(int page = 0, int pageSize = 5)
        {
            return _context.Categories.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public Category GetById(int id, bool withBooks = false)
        {
            var query = _context.Categories.AsQueryable();

            if (withBooks)
                query = query.Include(x => x.BookList);

            var category = query.FirstOrDefault(x => x.Id == id);
            return category;

        }

        public Category GetByName(string name, bool withBooks = false)
        {
            var query = _context.Categories.AsQueryable();

            if (withBooks)
                query = query.Include(x => x.BookList);

            if (name != null)
            {
                var category = query.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
                return category;

            }
            return query.FirstOrDefault(x => x.Name == name);

        }
    }
}
