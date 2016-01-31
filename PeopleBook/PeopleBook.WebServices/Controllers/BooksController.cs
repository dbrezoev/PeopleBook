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

    public class BooksController : BaseController
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost] // Admin only creates an empty book
        public IHttpActionResult Create()
        {
            var currentUserId = Thread.CurrentPrincipal.Identity.GetUserId();

            var id = this.bookService.Create(currentUserId);            

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