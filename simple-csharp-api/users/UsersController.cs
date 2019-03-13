using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using simple_csharp_api.Repository;

namespace simple_csharp_api.users
{
    [Route("/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private UserRepository repo;
        private readonly IRepository<User> _repository;

        public UsersController(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            List<User> users = _repository.Find();

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // GET /users/<id>
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = _repository.Get(id);  

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] User user)
        {
            Console.WriteLine(user);
            _repository.Create(user);
        }

        //// PUT /users/<id>
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE /users/<id>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //repo.Delete(id);
        }
    }
}