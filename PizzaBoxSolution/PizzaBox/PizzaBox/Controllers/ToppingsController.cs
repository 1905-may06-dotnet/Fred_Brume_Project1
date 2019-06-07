using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Models;
using Lib = PizzaBox.Domain;

namespace PizzaBox.Controllers
{
    public class ToppingsController : Controller
    {

        private readonly Lib.IRepository repository;

        public ToppingsController(Lib.IRepository repository)
        {
            this.repository = repository;
        }

     


        public IActionResult Topping(int pizza_Id)
        {
            //var user = TempData["user"];
            //TempData["user"] = user;

            List<Domain.Model.Toppings> toppings = repository.GetToppings(1);
            List<ToppingsModel> toppingModels = new List<ToppingsModel>();

            foreach(Domain.Model.Toppings topping in toppings)
            {
                ToppingsModel model = new ToppingsModel()
                {
                    TopId = topping.TopId,
                    TName = topping.TName,
                    T_Type = topping.T_Type,
                    Cost = topping.Cost, 
                    PizzaId = topping.PizzaId
                    
                };

                toppingModels.Add(model);
            }
            return View(toppingModels);
        }
    }
}