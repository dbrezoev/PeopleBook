namespace PeopleBook.DomainServices.Contracts
{
    using System.Linq;

    using PeopleBook.Models;
    using System;

    public interface IBookService : IService
    {
        IQueryable<Book> GetAll();

        Guid Create(string userId, string content);
    }
}
