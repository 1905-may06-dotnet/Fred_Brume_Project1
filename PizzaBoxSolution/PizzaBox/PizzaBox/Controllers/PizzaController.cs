using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Models;
using System;
using System.Collections.Generic;
using Lib = PizzaBox.Domain;

namespace PizzaBox.Controllers
{
    public class PizzaController : Controller
    {
        private readonly Lib.IRepository repository;
        

        public PizzaController(Lib.IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult PizzaDetails(IFormCollection collection, Models.PizzaModel pizzaModel)
        {
            int user = Convert.ToInt32(TempData["user"]);
            TempData["user"] = user;

            string toppingList = "";
            int id = Convert.ToInt32(pizzaModel.PType);

            if (pizzaModel.Toppingstring != null)
            {

                foreach (string s in pizzaModel.Toppingstring)
                {
                    toppingList += s + ",";
                }
            }

            if (pizzaModel != null)
            {


                List<PizzaModel> pizzaModels = new List<PizzaModel>();
                List<Domain.Model.Toppings> toppings = new List<Domain.Model.Toppings>();
                Domain.Model.Pizza pizza = repository.GetPizza(id);
                Domain.Model.Pizza pizzaSelected = repository.GetPizzaByAttributes(pizza.PType, pizzaModel.PSize, pizzaModel.Crust, pizza.SLocationId);


                PizzaModel model = new PizzaModel();

                model.PizzaId = pizzaSelected.PizzaId;
                model.PType = pizza.PType;
                model.PSize = pizzaModel.PSize;
                model.Crust = pizzaModel.Crust;
                model.PPrice = pizza.PPrice;
                model.SLocationId = pizza.SLocationId;
                model.Toppingstring = pizzaModel.Toppingstring;
                model.ToppingList = toppingList;


                Domain.Model.Toppings topp;

                foreach (string topping in model.Toppingstring)
                {
                    topp = repository.GetTopping(topping);
                    toppings.Add(topp);
                }

                //List<Domain.Model.Toppings> tops = repository.GetToppings(model.PizzaId);
                //List<string> topString = Lib.Handler.ToppingsHandler.AddDefaultToChosenToppings(model.Toppingstring, tops);

                //foreach (string topping in topString)
                //{
                //    topp = repository.GetTopping(topping);
                //    toppings.Add(topp);
                //}

                double totalOrderCost = Domain.Handler.OrderHandler.GetOrderCost(Convert.ToDouble(pizza.PPrice), toppings);

               pizzaModels.Add(model);

               TempData["PizzaId"] = model.PizzaId;
               TempData["PType"] = model.PType;
               TempData["PSize"] = model.PSize;
               TempData["Crust"] = model.Crust;
               TempData["PPrice"] = model.PPrice;
               TempData["SLocationId"] = model.SLocationId;
               TempData["ToppingList"] = toppingList;
               TempData["TotalCost"] = totalOrderCost;


                return View(pizzaModels);
            }

            return View();
        }
    }
}
