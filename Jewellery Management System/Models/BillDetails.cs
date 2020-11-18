using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Models
{
    [Serializable]
    public class BillDetails
    {
        public List<Product> products { get; set; }
        public Customer customer { get; set; }
        public Bill bill { get; set; }
    }
}
