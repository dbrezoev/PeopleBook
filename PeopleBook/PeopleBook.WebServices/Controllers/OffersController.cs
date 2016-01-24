namespace PeopleBook.WebServices.Controllers
{
    using System;
    using System.Web.Http;
    using System.Threading;    
    
    using Microsoft.AspNet.Identity;

    using Data;
    using PeopleBook.Models;

    public class OffersController : BaseController
    {
        public OffersController(IPeopleBookData data)
            : base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult CreateOffer(Guid bookId, string content)
        {
            var book = this.data.Books.Find(bookId);

            if (book == null)
            {
                return NotFound();
            }

            var newOffer = new Offer()
            {
                BookId = book.Id,
                UserId = Thread.CurrentPrincipal.Identity.GetUserId(),
                Content = content
            };

            this.data.Offers.Add(newOffer);
            this.data.SaveChanges();

            return this.Ok(newOffer.Id);
        }
    }
}