using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Jewellery_Management_System.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http;

namespace Jewellery_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private Owner owner;
        public IActionResult Index()
        {
            owner = DataManagement.ManageOwner.GetOwner();
            if (owner == null)
            {
                return RedirectToAction("OwnerSignUp");
            }
            else
            {
                HttpContext.Session.SetString("OwnerName", owner.Name);
                return View(owner);
            }
        }
        [HttpGet]
        public IActionResult OwnerSignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OwnerSignUp(Owner o)
        {
            DataManagement.ManageOwner.CreateOwner(o);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GeneratePreviousBill()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult EditOwner()
        {
            owner = DataManagement.ManageOwner.GetOwner();
            return View(owner);
        }
        [HttpPost]
        public IActionResult EditOwner(Owner o)
        {
            DataManagement.ManageOwner.CreateOwner(o);
            return RedirectToAction("Index");
        }
    }
}
