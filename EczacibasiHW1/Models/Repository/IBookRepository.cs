using EczacibasiHW1.Models.Entity;
using System.Collections.Generic;

namespace BookRentalApp.Data.Interface
{
    public interface IBookRepository
    {
        Book Add(Book book);
        Book Delete(int id);
        Book Update(int id, Book book);
        List<Book> Search(string title, string author, string publisher, string ISBN,
            int? categoryId, double? minPrice, string categoryName, bool? isAvailable);
        Book GetById(int id, bool withCategory = false);
        List<Book> GetAll(int page, int pageSize, string v);
        Book SetAvailability(int id, bool availability);
        List<Book> GetByTitle(string title, bool withCategory = false);
        List<Book> GetByISBN(string ISBN, bool withCategory = false);
    }
}
