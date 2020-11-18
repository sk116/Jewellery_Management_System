using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Models
{
    public class BillRepository : IBillRepository
    {
        private readonly ContextClass context;
        public BillRepository(ContextClass context)
        {
            this.context = context;
        }
        Bill IBillRepository.AddBill(Bill bill)
        {
            context.Bills.Add(bill);
            context.SaveChanges();
            return (bill);
        }
    }
}
