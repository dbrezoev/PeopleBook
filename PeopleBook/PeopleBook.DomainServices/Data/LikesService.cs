namespace PeopleBook.DomainServices.Data
{
    using System;
    using System.Linq;

    using PeopleBook.Data;
    using PeopleBook.DomainServices.Common;
    using PeopleBook.DomainServices.Contracts;
    using PeopleBook.Models;
    
    public class LikesService : BaseService, ILikesService
    {
        public LikesService(IPeopleBookData data)
            : base(data)
        {
        }

        public int Create(int chapterId, string userId)
        {
            var chapterToLike = this.Data.Chapters.Find(chapterId);
            
            var hasAlreadyLikedTheChapter = this.HasUserAlreadyLikedChapter(chapterId, userId);

            if (hasAlreadyLikedTheChapter)
            {
                throw new ArgumentException(string.Format(ServicesConstants.UserHasAlreadyLikedThisChapter, userId, chapterId));
            }

            var hasRightToLike = this.UserHasRightToLike(userId);

            if (!hasRightToLike)
            {
                throw new ArgumentException(string.Format(ServicesConstants.UserHasNoRightToLike, userId));
            }

            var like = new Like
            {
                UserId = userId.ToString(),
                ChapterId = chapterId
            };

            chapterToLike.Likes.Add(like);

            this.Data.SaveChanges();

            return like.Id;
        }

        public int Delete(int chapterId, string userId)
        {
            var chapterToUnLike = this.Data.Chapters.Find(chapterId);

            var hasAlreadyLikedTheChapter = this.HasUserAlreadyLikedChapter(chapterId, userId);

            if(!hasAlreadyLikedTheChapter)
            {
                throw new ArgumentException(string.Format(ServicesConstants.UserHasToLikeChapterBeforeUnlikeId, userId, chapterId));
            }

            var like = this.Data.Likes
                .All()
                .Where(l => l.UserId == userId)
                .Where(l => l.ChapterId == chapterId)
                .First();

            chapterToUnLike.Likes.Remove(like);

            this.Data.SaveChanges();

            return like.Id;
        }

        private bool UserHasRightToLike(string userId)
        {
            var result = this.Data.Users.Find(userId).CanLike;

            return result;
        }        

        private bool HasUserAlreadyLikedChapter(int chapterId, string userId)
        {
            var result = this.Data.Likes
                .All()
                .Where(l => l.UserId == userId)
                .Where(l => l.ChapterId == chapterId)
                .Any();

            return result;
        }
    }
}
