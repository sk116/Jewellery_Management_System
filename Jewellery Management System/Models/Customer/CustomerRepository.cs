using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ContextClass context;
        public CustomerRepository(ContextClass context)
        {
            this.context = context;
        }

        public Customer Delete(int customerId)
        {
            Customer cust = context.Customers.Find(customerId);
            if(cust != null)
            {
                context.Customers.Remove(cust);
                context.SaveChanges();
            }
            return cust;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return context.Customers;
        }

        public Customer GetCustomer(int CustomerId)
        {
            return context.Customers.Find(CustomerId);
        }

        public Customer Update(Customer customerchanges)
        {
            var customer = context.Customers.Attach(customerchanges);
            customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return customerchanges;
        }

        Customer ICustomerRepository.Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return customer;
        }

        Customer ICustomerRepository.FindCustomer(int id, string name, string mo_no)
        {
            IEnumerable<Customer> customers = context.Customers.Where(c => (c.CustomerId == id) || (c.Name == name) || (c.MobileNo == mo_no));
            if (customers.Count() == 0)
            {
                return null;
            }
            else
            {
                return customers.First();
            }
        }

        IEnumerable<Customer> ICustomerRepository.GetCustomersWithDebt()
        {
            return context.Customers.Where(c => c.Debt > 0);
        }
    }   
}
