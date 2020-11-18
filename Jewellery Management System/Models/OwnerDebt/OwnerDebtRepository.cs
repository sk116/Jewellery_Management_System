using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Models
{
    public class OwnerDebtRepository : IOwnerDebtRepository
    {
        private readonly ContextClass context;
        public OwnerDebtRepository(ContextClass context)
        {
            this.context = context;
        }
        public OwnerDebt Add(OwnerDebt owner)
        {
            context.OwnerDebts.Add(owner);
            context.SaveChanges();
            return owner; 
        }

        public OwnerDebt Delete(int Id)
        {
            OwnerDebt owner = context.OwnerDebts.Find(Id);
            if(owner != null)
            {
                context.OwnerDebts.Remove(owner);
                context.SaveChanges();
            }
            return owner;
        }

        public IEnumerable<OwnerDebt> GetAllOwnerDebts()
        {
            return context.OwnerDebts;
        }

        public OwnerDebt GetOwnerDebt(int Id)
        {
            OwnerDebt owner = context.OwnerDebts.Find(Id);
            return owner;
        }

        public OwnerDebt Update(OwnerDebt owner)
        {
            var ownerdebt = context.OwnerDebts.Attach(owner);
            ownerdebt.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return owner;
        }
    }
}
