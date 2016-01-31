using Microsoft.AspNet.Identity;
using PeopleBook.DomainServices.Contracts;
using PeopleBook.WebServices.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace PeopleBook.WebServices.Controllers
{
    public class FlagsController : ApiController
    {
        private readonly IFlagsService flagsService;

        public FlagsController(IFlagsService flagService)
        {
            this.flagsService = flagsService;
        }

        [HttpPost]
        public IHttpActionResult Create(FlagModel flagModel)
        {
            var currentUserId = Thread.CurrentPrincipal.Identity.GetUserId();

            var flagId = this.flagsService.Create(flagModel.ChapterId, currentUserId);

            return this.Ok(flagId);
        }
    }
}