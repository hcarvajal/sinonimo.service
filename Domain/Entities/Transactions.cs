using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("transaciones")]
    public class Transactions : BaseEntity
    {
        public Transactions(int vendorId, DateTime transactionDate, string type, string description, int? cancellationFlag, string? cancelledBy)
        {
            VendorId = vendorId;
            TransactionDate = transactionDate;
            Type = type;
            Description = description;
            CancellationFlag = cancellationFlag;
            CancelledBy = cancelledBy;
        }

        public int VendorId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? CancellationFlag { get; set; }
        public string? CancelledBy { get; set; }
       
    }
}
