using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleBook.WebServices.RequestModels
{
    public class ChapterModel
    {
        public string Content { get; set; }

        public string BookId { get; set; }

        public string UserId { get; set; }
    }
}