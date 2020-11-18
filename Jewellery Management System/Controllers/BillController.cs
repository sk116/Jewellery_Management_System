using Jewellery_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Controllers
{
    public class BillController:Controller
    {
        private readonly IProductRepository _prod;
        private readonly IBillRepository _bill;
        private readonly ICustomerRepository _cust;
        public Bill bill;
        public BillController(IProductRepository prod,IBillRepository bill,ICustomerRepository cust)
        {
            this._prod = prod;
            this._bill = bill;
            this._cust = cust;
        }

        [HttpGet]
        public IActionResult Create()
        {
            int ?num = HttpContext.Session.GetInt32("quantity");
            IEnumerable<Product> product = _prod.GetProducts();
            ViewBag.num = num;
            ViewBag.Name = HttpContext.Session.GetString("CName");
            return View(product);
        }

        [HttpPost,ActionName("Bill")]
        public IActionResult Create(int[] products)
        {
            Customer c = _cust.GetCustomer((int)HttpContext.Session.GetInt32("CID"));
            Owner owner = DataManagement.ManageOwner.GetOwner();
            float TotalAmount = 0;
            float TotalWeight = 0;
            List<Product> ps = new List<Product>();
            foreach( var product in products)
            {
                Product p = _prod.GetProduct(product);
                ps.Add(p);
                _prod.Delete(p.ProductId);
                TotalWeight = p.Weight;
                TotalAmount += p.LabourCharge * p.Weight;
            }
            
            TotalAmount += TotalWeight * ((owner.GoldPrice) / 10);
            bill = new Bill
            {
                BillDate = DateTime.Today,
                CurrentGoldPrice = owner.GoldPrice,
                TotalWeight = TotalWeight,
                TotalAmount = TotalAmount
            };
            _bill.AddBill(bill);
            c.Bills = new List<Bill>();
            c.Bills.Add(bill);
            _cust.Update(c);
            All a = new All
            {
                customer = c,
                owner = owner,
                bill = bill,
                products = ps
            };
            DataManagement.ManageBill.CreateBill(new BillDetails
            {
                bill = bill,
                customer = c,
                products = ps
            });
            return View("Bill", a);
        }
        [HttpPost]
        public IActionResult GeneratePreviousBill(int id)
        {
            BillDetails billDetails = DataManagement.ManageBill.GetBill(id);
            if (billDetails == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                All all = new All
                {
                    bill = billDetails.bill,
                    customer = billDetails.customer,
                    owner = DataManagement.ManageOwner.GetOwner(),
                    products = billDetails.products
                };
                return View("Bill", all);
            }
        }
        public IActionResult Bill(All a)
        {
            return View(a);
        }
    }
}
