using PeopleBook.DomainServices.Contracts;
using PeopleBook.WebServices.RequestModels;
namespace PeopleBook.WebServices.Controllers
{
    using System.Web.Http;

    public class FlagsController : BaseController
    {
        private readonly IFlagsService flagsService;

        public FlagsController(IFlagsService flagsService)
        {
            this.flagsService = flagsService;
        }

        [HttpPost]
        public IHttpActionResult Create(FlagModel flagModel)
        {
            var flagId = this.flagsService.Create(flagModel.ChapterId, this.CurrentUserId);

            return this.Ok(flagId);
        }
    }
}