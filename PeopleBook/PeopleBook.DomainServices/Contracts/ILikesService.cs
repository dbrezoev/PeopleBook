namespace PeopleBook.DomainServices.Contracts
{
    public interface ILikesService : IService
    {
        int Create(int chapterId, string userId);

        int Delete(int chapterId, string userId);
    }
}
