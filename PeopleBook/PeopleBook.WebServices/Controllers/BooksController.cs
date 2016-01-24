namespace PeopleBook.WebServices.Controllers
{
    using System;
    using System.Threading;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using Data;
    using PeopleBook.Models;
    

    public class BooksController : BaseController   
    {
        public BooksController(IPeopleBookData data)
            : base(data)
        {
        }

        [HttpPost] // Admin
        public IHttpActionResult Create()
        {
            var currentUserId = Thread.CurrentPrincipal.Identity.GetUserId();

            var newBook = new Book
            {
                UserId = currentUserId,
                DateCreated = DateTime.Now,
                BookState = BookState.Started,
                Content = "Pesho",
                Title = "Init",
            };

            this.data.Books.Add(newBook);
            this.data.SaveChanges();

            return this.Ok(newBook.Id);
        } 
        
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var allBooks = this.data.Books;

            return this.Ok(allBooks);
        }       
    }
}