using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Models
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);

        Customer GetCustomer(int CustomerId);

        IEnumerable<Customer> GetAllCustomers();

        Customer Update(Customer customerchanges);

        Customer Delete(int customerId);

        Customer FindCustomer(int id, string name, string mo_no);
        IEnumerable<Customer> GetCustomersWithDebt();
    }
}
