namespace PeopleBook.DomainServices.Contracts
{
    using System;

    public interface IChapterService : IService
    {
        int Create(string userId, Guid bookId, string chapterContent);

        int Delete(int chapterId);
    }
}
