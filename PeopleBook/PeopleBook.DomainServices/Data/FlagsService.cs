namespace PeopleBook.DomainServices.Data
{
    using PeopleBook.Data;
    using PeopleBook.DomainServices.Contracts;
    using PeopleBook.Models;

    public class FlagsService : BaseService, IFlagsService
    {
        public FlagsService(IPeopleBookData data)
            : base(data)
        {
        }

        public int Create(int chapterId, string userId)
        {
            var chapterToBeFlagged = this.Data.Chapters.Find(chapterId);

            var flag = new Flag
            {
                UserId = userId,
                ChapterId = chapterId
            };

            chapterToBeFlagged.Flags.Add(flag);

            this.Data.SaveChanges();

            return flag.Id;
        }
    }
}
