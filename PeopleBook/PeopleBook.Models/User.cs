namespace PeopleBook.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        private ICollection<Like> likes;
        private ICollection<Chapter> chapters;
        private ICollection<Flag> flags;
        private int symbolsAllowed;

        public User()
        {
            this.flags = new HashSet<Flag>();
            this.chapters = new HashSet<Chapter>();
            this.likes = new HashSet<Like>();
            this.symbolsAllowed = 200;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public int Age { get; set; }

        public int SymbolsAllowed
        {
            get
            {
                return this.symbolsAllowed;
            }
            set
            {
                this.symbolsAllowed = value;
            }
        }

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
