namespace PeopleBook.DomainServices.Data
{
    using System;
    using System.Linq;

    using PeopleBook.Data;
    using PeopleBook.Models;
    using Contracts;

    public class BookService : BaseService, IBookService
    {
        public BookService(IPeopleBookData data)
            : base(data)
        {
        }

        public IQueryable<Book> GetAll()
        {
            var result = this.Data.Books.All();

            return result;
        }

        public Guid Create(string userId)
        {
            var book = new Book
            {
                UserId = userId
            };

            this.Data.Books.Add(book);

            this.Data.SaveChanges();

            return book.Id;
        }

        public string Delete(string bookId)
        {
            var book = this.Data.Books.Find(new Guid(bookId));

            this.Data.Books.Delete(book);
            this.Data.SaveChanges();

            return book.Id.ToString();
        }

        public IQueryable<Book> Get(string bookId)
        {
            var query = this.Data.Books
                .All()
                .Where(b => b.Id.ToString() == bookId);

            return query;
        }
    }
}
