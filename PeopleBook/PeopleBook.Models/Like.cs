﻿namespace PeopleBook.Models
{
    public class Like
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int OfferId { get; set; }

        public virtual Offer Offer { get; set; }
    }
}