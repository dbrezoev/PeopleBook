namespace PeopleBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Offer
    {
        public Offer()
        {
            this.Likes = new HashSet<Like>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(1000)] // Admin has to change this
        public string Content { get; set; }

        [Required]
        public Guid BookId { get; set; }

        public virtual Book Book { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
