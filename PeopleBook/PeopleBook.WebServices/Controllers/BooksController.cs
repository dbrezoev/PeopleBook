namespace PeopleBook.WebServices.Controllers
{
    using System;
    using System.Threading;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using Data;
    using PeopleBook.Models;
    using DomainServices.Contracts;
    using System.Linq;

    public class BooksController : ApiController
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost] // Admin
        public IHttpActionResult Create([FromBody]string content)
        {
            var currentUserId = Thread.CurrentPrincipal.Identity.GetUserId();

            var id = this.bookService.Create(currentUserId, "dqdo mraz");
            //var newBook = new Book
            //{
            //    UserId = currentUserId,
            //    DateCreated = DateTime.Now,
            //    BookState = BookState.Started,
            //    Content = "Pesho",
            //    Title = "Init",
            //};

            //this.data.Books.Add(newBook);
            //this.data.SaveChanges();

            return this.Ok(id);
        } 
        
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var allBooks = this.bookService.GetAll().Select(b => new
            {
                Name = b.Content,
                State = b.BookState,
                DateCreated = b.DateCreated
            }).ToList();

            return this.Ok(allBooks);
        }       

    }
}