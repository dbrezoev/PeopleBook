﻿namespace PeopleBook.DomainServices.Contracts
{
    public interface IFlagsService : IService
    {
        int Create(int chapterId, string reason, string userId);
    }
}
