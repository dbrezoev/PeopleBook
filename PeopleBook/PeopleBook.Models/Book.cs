namespace PeopleBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        private ICollection<Chapter> chapters;

        public Book()
        {
            this.Id = Guid.NewGuid();
            this.BookState = BookState.InProgress;
            this.DateCreated = DateTime.Now;
            this.chapters = new HashSet<Chapter>();
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

        public virtual ICollection<Chapter> Chapters
        {
            get
            {
                return this.chapters;
            }
            set
            {
                this.chapters = value;
            }
        }
    }
}
