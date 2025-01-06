using System.ComponentModel.DataAnnotations;

namespace Models
{
    public abstract class BaseDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a user")]
        public string? CreatedBy { get; set; }

        [Required(ErrorMessage = "Please provice a date")]
        public DateTime Created { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Please provide a user")]
        public string? ModifiedBy { get; set; }  
        public DateTime Modified { get; set; } = DateTime.Now;

    }
}
