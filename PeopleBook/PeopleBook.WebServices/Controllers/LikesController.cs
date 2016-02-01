namespace PeopleBook.WebServices.Controllers
{
    using System.Threading;
    using System.Web.Http;

    using PeopleBook.DomainServices.Contracts;
    using PeopleBook.WebServices.RequestModels;    

    public class LikesController : BaseController
    {
        private readonly ILikesService likesService;

        public LikesController(ILikesService likesService)
        {
            this.likesService = likesService;
        }

        [HttpPost]
        public IHttpActionResult Create(LikeModel likeModel)
        {
            var id = this.likesService.Create(likeModel.ChapterId, this.CurrentUserId);

            return this.Ok(id);
        }

        [HttpDelete]
        public IHttpActionResult Delete(LikeModel likeModel)
        {
            var id = this.likesService.Delete(likeModel.ChapterId, this.CurrentUserId);

            return this.Ok(id);
        }
    }
}