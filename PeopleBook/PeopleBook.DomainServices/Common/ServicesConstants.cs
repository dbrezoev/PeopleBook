namespace PeopleBook.DomainServices.Common
{
    public class ServicesConstants
    {
        public readonly static string UserHasAlreadyFlaggedThisChapter = "User {0} has already flagged chapter with id {1}!";
        public readonly static string UserHasAlreadyLikedThisChapter = "User {0} has already liked chapter with id {1}!";
        public readonly static string UserHasToLikeChapterBeforeUnlikeId = "User {0} cannot unlike chapter with id {1} without liking it first!";
    }
}
