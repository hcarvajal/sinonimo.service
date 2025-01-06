using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.UserDTO
{
    public class UserForUpdateDTO
    {
        [Required(ErrorMessage = "Please provide a User Name")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Please provide a Password.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Please provide a First Name")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please provide an Email.")]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Role { get; set; }
        [Required(ErrorMessage = "Please provide a vendor Id")]
        public int? VendorId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
