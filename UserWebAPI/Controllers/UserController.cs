using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UserWebAPI.Models;

namespace UserWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                //get all users
                return context.Users.ToList();
            }
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            using (var context = new UserInfoContext())
            {
                //get user by id
                return context.Users.FirstOrDefault(u => u.Id == id);
            }
        }

        [HttpPost]
        public void Add([FromBody] User user)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                //add a user
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                //delete a user
                context.Users.Remove(context.Users.FirstOrDefault(u => u.Id == id));
                context.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                //update a user
                var entity = context.Users.FirstOrDefault(u => u.Id == id);

                entity.UserName = user.UserName;
                entity.Password = user.Password;
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;
                entity.ContactNo = user.ContactNo;
                entity.GenderId = user.GenderId;
                entity.DateOfBirth = user.DateOfBirth;

                context.SaveChanges();
            }
        }
    }
}
