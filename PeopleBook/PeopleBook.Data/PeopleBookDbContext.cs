namespace PeopleBook.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Migrations;
    using Models;
    

    public class PeopleBookDbContext : IdentityDbContext<User>, IPeopleBookDbContext
    {
        public PeopleBookDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PeopleBookDbContext, Configuration>());
        }

        public static PeopleBookDbContext Create()
        {
            return new PeopleBookDbContext();
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Offer> Offers { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
