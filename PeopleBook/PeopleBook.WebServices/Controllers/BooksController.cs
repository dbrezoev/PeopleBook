namespace PeopleBook.WebServices.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using DomainServices.Contracts;
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
            var id = this.bookService.Create(this.CurrentUserId);            

            return this.Ok(id);
        }

        [HttpDelete] // Admin only!
        public IHttpActionResult Remove([FromUri]string id)
        {
            var deletedBookId = this.bookService.Delete(id);

            return this.Ok(deletedBookId);
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

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            var book = this.bookService.Get(id).Select(b => new BookResponseModel
            {
                Content = b.Content,
                BookState = b.BookState,
                DateCreated = b.DateCreated,
                Title = b.Title
            }).FirstOrDefault();

            return this.Ok(book);
        }

    }
}