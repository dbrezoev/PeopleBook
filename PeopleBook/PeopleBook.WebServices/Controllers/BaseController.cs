namespace PeopleBook.WebServices.Controllers
{    
    using System.Threading;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    public abstract class BaseController : ApiController
    {
        private string currentUserId;

        protected string CurrentUserId
        {
            get
            {
                return Thread.CurrentPrincipal.Identity.GetUserId();
            }
        }
    }
}