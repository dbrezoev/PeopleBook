namespace PeopleBook.Data
{
    using System;
    using System.Collections.Generic;

    using Repositories;
    using Models;
    
    public class PeopleBookData : IPeopleBookData
    {
        private IPeopleBookDbContext context;
        private IDictionary<Type, object> repositories;

        public PeopleBookData() // mai ne mi trqbva
            : this(new PeopleBookDbContext())
        {
        }

        public PeopleBookData(IPeopleBookDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Like> Likes
        {
            get
            {
                return this.GetRepository<Like>();
            }
        }

        public IRepository<Book> Books
        {
            get
            {
                return this.GetRepository<Book>();
            }
        }  

        public IRepository<Chapter> Chapters
        {
            get
            {
                return this.GetRepository<Chapter>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EfRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
