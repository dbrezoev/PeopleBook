using PeopleBook.Data;
using PeopleBook.DomainServices.Common;
using PeopleBook.DomainServices.Contracts;
using PeopleBook.Models;
using System;
using System.Linq;

namespace PeopleBook.DomainServices.Data
{
    public class LikesService : BaseService, ILikesService
    {
        public LikesService(IPeopleBookData data)
            : base(data)
        {
        }

        public int Create(int chapterId, string userId)
        {
            var chapterToLike = this.Data.Chapters.Find(chapterId);

            //check if this user has already liked the chapter
            var hasAlreadyLikedTheChapter = this.Data.Likes
                .All()
                .Where(l => l.UserId == userId)
                .Where(l => l.ChapterId == chapterId)
                .Any();

            if (hasAlreadyLikedTheChapter)
            {
                throw new ArgumentException(string.Format(ServicesConstants.UserHasAlreadyLikedThisChapter, userId, chapterId));
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
    }
}
