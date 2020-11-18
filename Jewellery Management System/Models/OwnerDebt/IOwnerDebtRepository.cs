using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Models
{
    public interface IOwnerDebtRepository
    {
        OwnerDebt Add(OwnerDebt owner);

        IEnumerable<OwnerDebt> GetAllOwnerDebts();

        OwnerDebt GetOwnerDebt(int Id);

        OwnerDebt Update(OwnerDebt owner);

        OwnerDebt Delete(int Id);
    }
}
