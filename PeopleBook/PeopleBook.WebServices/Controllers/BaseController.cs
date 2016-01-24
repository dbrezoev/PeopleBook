namespace PeopleBook.WebServices.Controllers
{
    using System.Web.Http;
    using Data;

    [AllowAnonymous]
    public abstract class BaseController : ApiController
    {
        protected IPeopleBookData data;        

        protected BaseController(IPeopleBookData data)
        {
            this.data = data;
        }
    }
}