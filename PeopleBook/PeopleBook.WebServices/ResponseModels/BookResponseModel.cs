using PeopleBook.Models;
using System;

namespace PeopleBook.WebServices.ResponseModels
{
    public class BookResponseModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public BookState BookState { get; set; }
    }
}