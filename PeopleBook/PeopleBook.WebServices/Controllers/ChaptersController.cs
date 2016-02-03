namespace PeopleBook.WebServices.Controllers
{        
    using System.Web.Http;

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
            var id = this.chapterService.Create(this.CurrentUserId, chapterModel.BookId, chapterModel.Content);

            return this.Ok(id);
        }

        [HttpDelete] // admin only
        public IHttpActionResult Delete(int chapterId)
        {
            var id = this.chapterService.Delete(chapterId);

            return this.Ok(id);
        }
    }
}