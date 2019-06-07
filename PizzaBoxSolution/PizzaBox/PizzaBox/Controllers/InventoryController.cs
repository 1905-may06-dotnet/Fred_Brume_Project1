using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Models;
using Lib = PizzaBox.Domain;

namespace PizzaBox.Controllers
{
    public class InventoryController : Controller
    {
        private readonly Lib.IRepository repository;

        public InventoryController(Lib.IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult PizzaInventory()
        {
            int userId = Convert.ToInt32(TempData["user"]);
            TempData["user"] = userId;


            Domain.Model.Puser user = repository.GetUser(userId);
            List<Domain.Model.Pizza> pizzas = repository.GetPizzas(user.LocationId);

            List<PizzaModel> pizzModels = new List<PizzaModel>();

            foreach (Domain.Model.Pizza pizza in pizzas)
            {
                PizzaModel model = new PizzaModel()
                {
                    PizzaId = pizza.PizzaId,
                    PType = pizza.PType,
                    PSize = pizza.PSize,
                    Crust = pizza.Crust,
                    PPrice = pizza.PPrice,
                    SLocationId = pizza.SLocationId
                };

                pizzModels.Add(model);
            }


            return View(pizzModels);
        }

        public IActionResult ToppingsInventory()
        {
            return View();
        }
    }
}