using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Model;
using PizzaBox.Models;
using Lib = PizzaBox.Domain;

namespace PizzaBox.Controllers
{
    public class HomeController : Controller
    {

        private readonly Lib.IRepository repository;

        public HomeController(Lib.IRepository repository)
        {
            this.repository = repository;
        }

        List<Plocation> locations = new List<Plocation>();
        List<PlocationModel> locationModels = new List<PlocationModel>();
        PlocationModel locationModel;

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Login");
        }

        public IActionResult CustomerMenu()
        {

            return View();
        }

        public IActionResult EmployeeMenu()
        {

            return View();
        }

        public IActionResult Location()
        {
            locations = repository.GetLocations();

             foreach(Plocation location in locations)
            {
                locationModel = new PlocationModel()
                {
                    LocationId = location.LocationId,
                    Street = location.Street,
                    City = location.City,
                    PState = location.PState,
                    Zipcode = location.Zipcode
                };

                locationModels.Add(locationModel);
            }
            
            return View(locationModels);
        }

        public IActionResult Pizza(int id)
        {
           
            List<Pizza> pizzas = repository.GetPizzasFromLocation(id);
            List<PizzaModel> pizzaModels = new List<PizzaModel>();
            List<ToppingsModel> toppModels = new List<ToppingsModel>();
            List<Domain.Model.Toppings> toppings = repository.GetToppings(Convert.ToInt32(id));


            int userId = Convert.ToInt32(TempData["user"]);
            bool validateDate = Lib.Handler.OrderHandler.CheckOrderDateTime(repository.GetOrders(), 
                repository.GetLocation(id), repository.GetUser(userId));

            TempData["user"] = userId;

            if (validateDate == true)
            {

                if (pizzas != null)
                {
                    foreach (Domain.Model.Toppings topp in toppings)
                    {
                        ToppingsModel topModel = new ToppingsModel()
                        {
                            TopId = topp.TopId,
                            TName = topp.TName,
                            T_Type = topp.T_Type,
                            Cost = topp.Cost
                        };

                        toppModels.Add(topModel);

                    }

                    foreach (Pizza pizza in pizzas)
                    {
                        PizzaModel pizzaModel = new PizzaModel()
                        {
                            PizzaId = pizza.PizzaId,
                            PType = pizza.PType,
                            PSize = pizza.PSize,
                            Crust = pizza.Crust,
                            PPrice = pizza.PPrice,
                            SLocationId = pizza.SLocationId
                        };

                        pizzaModels.Add(pizzaModel);
                    }
                    ViewBag.toppingsModel = toppModels;
                    return View(pizzaModels);
                }
                else
                {
              
                }


            }
           
         return RedirectToAction("Message");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Message()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
