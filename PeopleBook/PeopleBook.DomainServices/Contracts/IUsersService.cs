using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleBook.DomainServices.Contracts
{
    public interface IUsersService
    {
        void AddRole(string userId);

        void RemoveRole(string userId);

        void ForbidLikes(string userId);

        void ForbidFlags(string userId);
    }
}
