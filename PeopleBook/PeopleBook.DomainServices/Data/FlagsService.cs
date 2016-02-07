namespace PeopleBook.DomainServices.Data
{
    using System;
    using System.Linq;

    using PeopleBook.Data;
    using Common;
    using PeopleBook.DomainServices.Contracts;
    using PeopleBook.Models;
    

    public class FlagsService : BaseService, IFlagsService
    {
        public FlagsService(IPeopleBookData data)
            : base(data)
        {
        }

        public int Create(int chapterId, string reason, string userId)
        {
            var chapterToBeFlagged = this.Data.Chapters.Find(chapterId);
            bool hasALreadyFLaggedTheChapter = this.UserALreadyFlaggedTheChapter(chapterId, userId);

            if (hasALreadyFLaggedTheChapter)
            {
                throw new ArgumentException(string.Format(ServicesConstants.UserHasAlreadyFlaggedThisChapter, userId, chapterId));
            }

            var userHasRightToFlag = this.UserHasRightToFlag(userId);

            if (!userHasRightToFlag)
            {
                throw new ArgumentException(string.Format(ServicesConstants.UserHasNoRightToFlag, userId));
            }

            var flag = new Flag
            {
                UserId = userId,
                ChapterId = chapterId,
                Reason = reason
            };

            chapterToBeFlagged.Flags.Add(flag);

            this.Data.SaveChanges();

            return flag.Id;
        }

        private bool UserALreadyFlaggedTheChapter(int chapterId, string userId)
        {

            var result =  this.Data.Flags
                .All()
                .Where(f => f.UserId == userId)
                .Where(f => f.ChapterId == chapterId).Any();

            return result;
        }

        private bool UserHasRightToFlag(string userId)
        {
            var result = this.Data.Users.Find(userId).CanFlag;

            return result;
        }
    }
}
