using PeopleBook.Data;
using PeopleBook.DomainServices.Contracts;
using PeopleBook.Models;
using System;
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
