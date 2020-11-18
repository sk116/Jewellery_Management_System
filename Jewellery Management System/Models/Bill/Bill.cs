using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Models
{
    [Serializable]
    public class Bill
    {
        public int BillId { get; set; }
        public DateTime BillDate { get; set; }
        public float CurrentGoldPrice { get; set; }
        public float TotalWeight { get; set; }
        public float TotalAmount { get; set; }

    }
}
