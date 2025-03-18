using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Form_API.Classes;

namespace Web_Form_API.Repository
{
    public interface IUsersRepository : IGenericRepository<UserBase>
    {
        // route to get all users
        IEnumerable<UserBase> GetAllUsers();

        UserBase GetUserByEmail(string email);
    }
}
