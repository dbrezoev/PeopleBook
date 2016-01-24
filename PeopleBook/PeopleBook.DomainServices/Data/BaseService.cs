namespace PeopleBook.DomainServices.Data
{
    using PeopleBook.Data;
    using PeopleBook.DomainServices.Contracts;

    public class BaseService : IService
    {
        private readonly IPeopleBookData data;        

        public BaseService(IPeopleBookData data)
        {
            this.data = data;
        }

        protected IPeopleBookData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}
