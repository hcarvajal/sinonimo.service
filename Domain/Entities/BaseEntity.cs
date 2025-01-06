using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {

        [Key]
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime Created { get; set; } 
        public string? ModifiedBy { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
