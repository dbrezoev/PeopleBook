namespace PeopleBook.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public Book()
        {
            this.Id = Guid.NewGuid();
            this.BookState = BookState.Started;
        }

        public Guid Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public BookState BookState { get; set; }

        [StringLength(20)]
        public string Title { get; set; }

        [StringLength(200)]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
