using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Models
{
    public interface IBillRepository
    {
        Bill AddBill(Bill bill);
    }
}
