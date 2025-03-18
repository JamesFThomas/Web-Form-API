using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Form_API.Classes;
using Web_Form_API.Repository;

namespace Web_Form_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        // use UsersRepository for users specific routes
        private readonly IUsersRepository _usersRespository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRespository = usersRepository;
        }

        // get all users 
        [HttpGet]
        public ActionResult<IEnumerable<UserBase>> Get()
        {
            var users = _usersRespository.GetAllUsers();

            return Ok(users);
        }

        //GetUserByEmail
        // get all users 
        [HttpGet("{email}")]
        public ActionResult<UserBase> Get(string email)
        {
            var user = _usersRespository.GetUserByEmail(email);

            if (user == null) { return NotFound(); }

            return Ok(user);
        }

    }
}
