namespace PeopleBook.WebServices.Controllers
{        
    using System.Threading;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using PeopleBook.DomainServices.Contracts;
    using PeopleBook.WebServices.RequestModels;

    public class ChaptersController : BaseController
    {
        private readonly IChapterService chapterService;

        public ChaptersController(IChapterService chapterService)
        {
            this.chapterService = chapterService;
        }

        [HttpPost]
        public IHttpActionResult Create(ChapterModel chapterModel)
        {
            var currentUserId = Thread.CurrentPrincipal.Identity.GetUserId();

            this.chapterService.Create(currentUserId, chapterModel.BookId, chapterModel.Content);

            return this.Ok();
        }
    }
}