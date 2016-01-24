namespace PeopleBook.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    public class User : IdentityUser
    {
        private ICollection<Like> likes;
        private ICollection<Offer> offers;
        private ICollection<Flag> flags;

        public User()
        {
            this.flags = new HashSet<Flag>();
            this.offers = new HashSet<Offer>();
            this.likes = new HashSet<Like>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public bool Gender { get; set; }

        public ICollection<Offer> Offers
        {
            get
            {
                return this.offers;
            }
            set
            {
                this.offers = value;
            }
        }

        public ICollection<Flag> Flags
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

        public ICollection<Like> Likes
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
