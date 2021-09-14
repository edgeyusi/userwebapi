using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UserWebAPI.Models;

namespace UserWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Address> GetAll()
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                //get all addresses
                return context.Addresses.ToList();
            }
        }

        [HttpGet("{id}")]
        public Address Get(int id)
        {
            using (var context = new UserInfoContext())
            {
                //get address by id
                return context.Addresses.FirstOrDefault(a => a.Id == id);
            }
        }

        [HttpPost]
        public void Add([FromBody] Address address)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                //add an address
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
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Address address)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                //update an address
                var entity = context.Addresses.FirstOrDefault(a => a.Id == id);

                entity.AddressLine1 = address.AddressLine1;
                entity.AddressLine2 = address.AddressLine2;
                entity.City = address.City;
                entity.State = address.State;
                entity.Country = address.Country;
                entity.ZipCode = address.ZipCode;

                context.SaveChanges();
            }
        }
    }
}
