namespace PeopleBook.Data
{    
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IPeopleBookDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Book> Books { get; set; }

        IDbSet<Like> Likes { get; set; }

        IDbSet<Offer> Offers { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
