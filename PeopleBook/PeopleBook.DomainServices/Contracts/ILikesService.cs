namespace PeopleBook.DomainServices.Contracts
{
    public interface ILikesService : IService
    {
        int Create(int chapterId, string userId);
    }
}
