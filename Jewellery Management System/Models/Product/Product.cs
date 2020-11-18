using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Models
{
    [Serializable]
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public float Weight { get; set; }

        public float LabourCharge { get; set; }

    }
}
