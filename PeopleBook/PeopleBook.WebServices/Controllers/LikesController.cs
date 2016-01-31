namespace PeopleBook.WebServices.Controllers
{
    using System.Threading;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using PeopleBook.DomainServices.Contracts;
    using PeopleBook.WebServices.RequestModels;    

    public class LikesController : ApiController
    {
        private readonly ILikesService likesService;

        public LikesController(ILikesService likesService)
        {
            this.likesService = likesService;
        }

        [HttpPost]
        public IHttpActionResult Create(LikeModel likeModel)
        {
            var currentUserId = Thread.CurrentPrincipal.Identity.GetUserId();
            var id = this.likesService.Create(likeModel.ChapterId, currentUserId);

            return this.Ok(id);
        }
    }
}