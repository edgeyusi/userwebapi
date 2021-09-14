using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UserWebAPI.Models
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
        }

        //This is the application user.
        public int Id { get; set; }

        [Required(ErrorMessage = "UserName field is required")]
        [StringLength(20, ErrorMessage = "UserName must be between 4 and 20 characters.", MinimumLength = 4)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [StringLength(20, ErrorMessage = "Password must be between 8 and 20 characters.", MinimumLength = 8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "FirstName field is required")]
        [StringLength(30, ErrorMessage = "Password must be between 2 and 30 characters.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName field is required")]
        [StringLength(30, ErrorMessage = "Password must be between 2 and 30 characters.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ContactNo field is required")]
        [StringLength(20, ErrorMessage = "Password must be between 10 and 20 characters.", MinimumLength = 10)]
        public string ContactNo { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
