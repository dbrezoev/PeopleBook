namespace PeopleBook.WebServices.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Data;

    public class UsersController : BaseController
    {
        public UsersController(IPeopleBookData data)
            :base (data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var allUsers = this.data.Users.All().Select(u => new
            {
               Name = u.Email
            }).ToList();

            return this.Ok(allUsers);
        }
    }
}