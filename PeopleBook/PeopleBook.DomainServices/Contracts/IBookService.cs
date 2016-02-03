namespace PeopleBook.DomainServices.Contracts
{
    using System;
    using System.Linq;

    using PeopleBook.Models;
    
    public interface IBookService : IService
    {
        IQueryable<Book> GetAll();

        Guid Create(string userId);

        string Delete(string bookId);

        IQueryable<Book> Get(string bookId);
    }
}
