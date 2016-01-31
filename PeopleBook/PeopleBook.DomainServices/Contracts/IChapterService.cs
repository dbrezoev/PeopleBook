using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleBook.DomainServices.Contracts
{
    public interface IChapterService : IService
    {
        int Create(string userId, Guid bookId, string chapterContent);
    }
}
