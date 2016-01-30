namespace PeopleBook.Data
{
    using Repositories;
    using Models;

    public interface IPeopleBookData
    {
        IRepository<User> Users { get; }

        IRepository<Book> Books { get; }

        IRepository<Chapter> Offers { get; }

        IRepository<Like> Likes { get; }

        void SaveChanges();
    }
}
