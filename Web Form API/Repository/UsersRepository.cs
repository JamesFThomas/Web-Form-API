using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_Form_API.Classes;
using Web_Form_API.Data;

namespace Web_Form_API.Repository
{
    public class UsersRepository : GenericRepository<UserBase>, IUsersRepository
    {

        // local variable to access / return db data 
        private readonly DbContext _formDBContext;

        public UsersRepository(FormDBContext formDBContext) : base(formDBContext)
        {
            _formDBContext = formDBContext;

        }

        public void AddUser(UserBase user)
        {
            // Add the user to the Users table
            _formDBContext.Add(user);
                    
            // Save changes to the database
            _formDBContext.SaveChanges();

        }

        public IEnumerable<UserBase> GetAllUsers()
        {
            return _formDBContext.Set<UserBase>().ToList();
        }

  
        // TODO update to use non case sensitivity and matching on username and email
        public UserBase GetUserByEmail(string email)
        {
            var user = _formDBContext.Set<UserBase>().FirstOrDefault(user => user.Email == email);

            return user;
        }
    }
}
