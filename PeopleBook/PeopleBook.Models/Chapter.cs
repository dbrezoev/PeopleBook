namespace PeopleBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Chapter
    {
        private ICollection<Flag> flags;
        private ICollection<Like> likes;

        public Chapter()
        {
            this.flags = new HashSet<Flag>();
            this.likes = new HashSet<Like>();
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

        public virtual ICollection<Flag> Flags
        {
            get
            {
                return this.flags;
            }
            set
            {
                this.flags = value;
            }
        }

        public virtual ICollection<Like> Likes
        {
            get
            {
                return this.likes;
            }
            set
            {
                this.likes = value;
            }
        }
    }
}
