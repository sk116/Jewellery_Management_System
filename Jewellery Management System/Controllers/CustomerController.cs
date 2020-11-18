using Jewellery_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Controllers
{
   

    public class CustomerController:Controller
    {
        private readonly ICustomerRepository _cust;

        public CustomerController(ICustomerRepository cust)
        {
            this._cust = cust;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer,int productquantity)
        {
            if(ModelState.IsValid)
            {
                Customer customerinstance = new Customer
                {
                    Name = customer.Name,
                    MobileNo = customer.MobileNo,
                    Debt = 0,
                };
                _cust.Add(customerinstance);
                HttpContext.Session.SetInt32("quantity", productquantity);
                HttpContext.Session.SetString("CName", customerinstance.Name);
                HttpContext.Session.SetInt32("CID", customerinstance.CustomerId);
                return RedirectToAction("Create", "Bill");
            }
            return View();
        }
        public IActionResult ViewCustomer()
        {
            var model = _cust.GetAllCustomers();
            return View(model);
        }
        public IActionResult CustomersWithDebt()
        {
            var model = _cust.GetCustomersWithDebt();
            return View(model);
        }

        [HttpGet]
        public IActionResult EditDebt(int id)
        {
            Customer cust = _cust.GetCustomer(id);
            if (cust == null)
            {
                return RedirectToAction("ViewCustomer");
            }
            Customer newcustomer = new Customer
            {
                CustomerId = cust.CustomerId,
                Name = cust.Name,
                MobileNo = cust.MobileNo,
                Debt = cust.Debt
            };
            return View(newcustomer);
        }

        [HttpPost]
        public IActionResult EditDebt(Customer customer)
        {
            Customer cust = _cust.GetCustomer(customer.CustomerId);
            cust.Debt = customer.Debt;
            Customer updatedcust = _cust.Update(cust);
            return RedirectToAction("ViewCustomer");
        }
        [HttpGet]
        public IActionResult GetID()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FindCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindCustomer(int id,string name,string no,int productquantity)
        {
            Customer customer = _cust.FindCustomer(id, name, no);
            if (customer == null)
            {
                return RedirectToAction("Create");
            }
            else
            {
                HttpContext.Session.SetInt32("quantity", productquantity);
                HttpContext.Session.SetString("CName", customer.Name);
                HttpContext.Session.SetInt32("CID", customer.CustomerId);
                return RedirectToAction("Create", "Bill");
            }
        }
    }
}
