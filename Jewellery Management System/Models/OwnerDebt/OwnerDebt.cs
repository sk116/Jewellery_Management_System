using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Models
{
    public class OwnerDebt
    {
        public int Id { get; set; }

        [Required]
        public string CreditorName { get; set; }

        [Required]
        public string ProductName { get; set; }

        public float DebtAmount { get; set; }
    }
}
