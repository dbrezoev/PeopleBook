using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleBook.WebServices.RequestModels
{
    public class ChapterModel
    {
        public string Content { get; set; }

        public Guid BookId { get; set; }

        public Guid UserId { get; set; }
    }
}