﻿namespace PeopleBook.Models
{
    public class Flag
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ChapterId { get; set; }

        public virtual Chapter Chapter { get; set; }
    }
}
