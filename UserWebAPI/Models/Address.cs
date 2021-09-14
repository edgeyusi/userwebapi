using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UserWebAPI.Models
{
    public partial class Address
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserId field is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "AddressLine1 field is required")]
        [StringLength(120, ErrorMessage = "AddressLine1 must be between 5 and 120 characters.", MinimumLength = 5)]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "City field is required.")]
        [StringLength(30, ErrorMessage = "City must be between 2 and 30 characters.", MinimumLength = 2)]
        public string City { get; set; }

        [Required(ErrorMessage = "State field is required.")]
        [StringLength(30, ErrorMessage = "State must be between 2 and 30 characters.", MinimumLength = 2)]
        public string State { get; set; }

        [Required(ErrorMessage = "Country field is required.")]
        [StringLength(30, ErrorMessage = "Country must be between 2 and 30 characters.", MinimumLength = 2)]
        public string Country { get; set; }

        [Required(ErrorMessage = "ZipCode field is required.")]
        [StringLength(10, ErrorMessage = "ZipCode must be between 3 and 10 characters.", MinimumLength = 3)]
        public string ZipCode { get; set; }
        
        public virtual User User { get; set; }
    }
}
