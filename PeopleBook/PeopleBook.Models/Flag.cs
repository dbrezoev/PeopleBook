using System;

namespace PeopleBook.Models
{
    public class Flag
    {
        public Flag()
        {
            this.DateCreated = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Reason { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ChapterId { get; set; }

        public virtual Chapter Chapter { get; set; }
    }
}
