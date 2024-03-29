﻿using EczacibasiHW1.Models.Entity;
using System.Collections.Generic;

namespace BookRentalApp.Data.Interface
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        Category Delete(int id);
        Category Update(int id, Category category);
        List<Category> GetAll(int page, int pageSize);
        Category GetById(int id, bool withBooks = false);
        Category GetByName(string name, bool withBooks = false);
    }
}
