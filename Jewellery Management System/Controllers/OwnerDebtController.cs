using Jewellery_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Controllers
{
    public class OwnerDebtController:Controller
    {
        private readonly IOwnerDebtRepository _owner;
        public OwnerDebtController(IOwnerDebtRepository owner)
        {
            this._owner = owner;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OwnerDebt ownerdebt)
        {
            if (ModelState.IsValid)
            {
                OwnerDebt odebtinstance = new OwnerDebt
                {
                    CreditorName = ownerdebt.CreditorName,
                    ProductName = ownerdebt.ProductName,
                    DebtAmount = ownerdebt.DebtAmount
                };
                _owner.Add(odebtinstance);
                return RedirectToAction("ViewOwnerDebt");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            OwnerDebt owner = _owner.GetOwnerDebt(id);
            return View(owner);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var owner = _owner.GetOwnerDebt(id);
            _owner.Delete(owner.Id);
            return RedirectToAction("viewOwnerDebt");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            OwnerDebt owner = _owner.GetOwnerDebt(id);
            OwnerDebt own = new OwnerDebt
            {
                CreditorName = owner.CreditorName,
                ProductName = owner.ProductName,
                DebtAmount = owner.DebtAmount,
                Id = owner.Id
            };
            return View(own);
        }

        [HttpPost]
        public IActionResult Edit(OwnerDebt own)
        {
            if(ModelState.IsValid)
            {
                OwnerDebt own1 = _owner.GetOwnerDebt(own.Id);

                own1.CreditorName = own.CreditorName;
                own1.DebtAmount = own.DebtAmount;
                own1.ProductName = own.ProductName;
                OwnerDebt owner1 = _owner.Update(own1);
                return RedirectToAction("viewOwnerDebt");
            }
            return View();
        }

        public IActionResult ViewOwnerDebt()
        {
            var ownerdebts = _owner.GetAllOwnerDebts();
            return View(ownerdebts);
        }

    }
}
