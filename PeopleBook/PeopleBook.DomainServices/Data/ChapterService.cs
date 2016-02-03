namespace PeopleBook.DomainServices.Data
{
    using System;

    using PeopleBook.DomainServices.Contracts;
    using PeopleBook.Models;
    using PeopleBook.Data;

    public class ChapterService : BaseService, IChapterService
    {
        public ChapterService(IPeopleBookData data)
             : base(data)
        {
        }       

        public int Create(string userId, Guid bookId, string chapterContent)
        {
            var book = this.Data.Books.Find(bookId);

            var chapter = new Chapter
            {
                UserId = userId,
                BookId = bookId,
                Content = chapterContent
            };

            book.Chapters.Add(chapter);

            this.Data.SaveChanges();

            return chapter.Id;
        }

        public int Delete(int chapterId)
        {
            var chapterToDelete = this.Data.Chapters.Find(chapterId);

            this.Data.Chapters.Delete(chapterToDelete);
            this.Data.SaveChanges();

            return chapterToDelete.Id;
        }
    }
}
