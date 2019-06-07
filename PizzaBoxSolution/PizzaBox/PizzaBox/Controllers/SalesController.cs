using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PizzaBox.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Sales()
        {
    
            return View();
        }
    }
}