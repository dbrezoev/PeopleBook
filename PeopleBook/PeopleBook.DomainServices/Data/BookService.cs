namespace PeopleBook.DomainServices.Data
{
    using System.Linq;

    using PeopleBook.Data;
    using PeopleBook.Models;
    using Contracts;
    using System.Threading.Tasks;
    using System;

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

        public void SetFirstChapter(string userId, Guid bookId, string chapterContent)
        {
            var book = this.Data.Books.Find(bookId);

            var chapter = new Chapter
            {
                UserId = userId,               
                BookId = bookId,
                Content = chapterContent
            };

            book.Chapters.Add(chapter);

            this.Data.SaveChanges();
        }
    }
}
