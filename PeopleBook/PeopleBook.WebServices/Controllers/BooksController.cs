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
    using RequestModels;
    using ResponseModels;

    public class BooksController : ApiController
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost] // Admin
        public IHttpActionResult Create(BookModel book)
        {
            var currentUserId = Thread.CurrentPrincipal.Identity.GetUserId();

            var id = this.bookService.Create(currentUserId, book.Content);            

            return this.Ok(id);
        } 
        
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var allBooks = this.bookService.GetAll().Select(b => new BookResponseModel
            {
                Content = b.Content,
                BookState = b.BookState,
                DateCreated = b.DateCreated,
                Title = b.Title
            }).ToList();

            return this.Ok(allBooks);
        }       

    }
}