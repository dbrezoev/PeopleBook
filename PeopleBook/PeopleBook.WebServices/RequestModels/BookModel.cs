namespace PeopleBook.WebServices.RequestModels
{
    using System;

    public class BookModel
    {
        public int UserId { get; set; }

        public Guid BookId { get; set; }

        public string ChapterContent { get; set; }
    }
}