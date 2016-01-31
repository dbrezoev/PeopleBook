namespace PeopleBook.DomainServices.Data
{
    using PeopleBook.Data;
    using Common;
    using PeopleBook.DomainServices.Contracts;
    using PeopleBook.Models;
    using System;
    using System.Linq;

    public class FlagsService : BaseService, IFlagsService
    {
        public FlagsService(IPeopleBookData data)
            : base(data)
        {
        }

        public int Create(int chapterId, string userId)
        {
            var chapterToBeFlagged = this.Data.Chapters.Find(chapterId);

            //check if this user has already flagged this chapter
            var hasALreadyFLaggedTheChapter = this.Data.Flags
                .All()
                .Where(f => f.UserId == userId)
                .Where(f => f.ChapterId == chapterId).Any();

            if (hasALreadyFLaggedTheChapter)
            {
                throw new ArgumentException(string.Format(ServicesConstants.UserHasAlreadyFlaggedThisChapter, userId, chapterId));
            }

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
