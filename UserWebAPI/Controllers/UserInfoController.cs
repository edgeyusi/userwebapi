using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UserWebAPI.Models;

namespace UserWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInfoController : ControllerBase
    {
        //from home pc
        //done from office pc
        [HttpGet]
        public IEnumerable<VEAllUser> GetAllUsers()
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                //get all users' info with their address
                return context.VEAllUsers.ToList();
            }
        }

        [HttpGet("{id}")]
        public VEAllUser GetUser(int id)
        {
            using (var context = new UserInfoContext())
            {
                //get user info and address by id
                return context.VEAllUsers.FirstOrDefault(u => u.Id == id);
            }
        }

        [HttpPost]
        public void Add([FromBody] Address address)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                //add a user and address
                context.Addresses.Add(address);
                context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                //delete an address
                context.Addresses.Remove(context.Addresses.FirstOrDefault(a => a.Id == id));
                context.SaveChanges();
            }

            using (UserInfoContext context = new UserInfoContext())
            {
                //delete a user
                context.Users.Remove(context.Users.FirstOrDefault(u => u.Id == id));
                context.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] VEAllUser alluser)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                //update a user and address
                var entity = context.VEAllUsers.FirstOrDefault(a => a.Id == id);

                entity.Username = alluser.Username;
                entity.Password = alluser.Password;
                entity.FirstName = alluser.FirstName;
                entity.LastName = alluser.LastName;
                entity.ContactNo = alluser.ContactNo;
                entity.DateOfBirth = alluser.DateOfBirth;

                entity.AddressLine1 = alluser.AddressLine1;
                entity.AddressLine2 = alluser.AddressLine2;
                entity.City = alluser.City;
                entity.State = alluser.State;
                entity.Country = alluser.Country;
                entity.ZipCode = alluser.ZipCode;

                context.SaveChanges();
            }
        }
    }
}
