using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Models
{
    public class All
    {
        public Customer customer { get; set; }
        public List<Product> products { get; set; }
        public Bill bill { get; set; }
        public Owner owner { get; set; }
    }
}
