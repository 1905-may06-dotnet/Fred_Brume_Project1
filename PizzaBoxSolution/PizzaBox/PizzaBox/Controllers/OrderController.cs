using Microsoft.AspNetCore.Mvc;
using PizzaBox.Models;
using System;
using System.Collections.Generic;

using Lib = PizzaBox.Domain;

namespace PizzaBox.Controllers
{
    public class OrderController : Controller
    {
        static PorderModel orderModel;

        private readonly Lib.IRepository repository;
        List<PorderModel> ordeers = new List<PorderModel>();

        public OrderController(Lib.IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult PlaceOrder()
        {

            int userId = Convert.ToInt32(TempData["user"]);
            string orderCost = TempData["TotalCost"] + "";
            int pizzaId = Convert.ToInt32(TempData["PizzaId"]);
            int locationId = Convert.ToInt32(TempData["SLocationId"]);

            repository.AddOrder(new Lib.Model.Porder()
            {
                PDate = DateTime.Now.ToString("M/d/yyyy"),
                PTime = DateTime.Now.ToShortTimeString(),
                PUserId = userId,
                OrderCost = orderCost,
                PizzaId = pizzaId,
                CLocationId = locationId

            });

            if (repository.GetCustomer(userId) != null)
            {
                repository.AddCustomer(new Lib.Model.Customer()
                {
                    PUserId = orderModel.PUserId
                });
            }


            return Content("Your Order Has Been Placed");

        }

        public IActionResult ViewCustomerOrders()
        {
     
            int userId = Convert.ToInt32(TempData["user"]);
            List<Domain.Model.Porder> orders = repository.GetOrders(userId);

            List<PorderModel> orderModels = new List<PorderModel>();

            foreach(Domain.Model.Porder order in orders)
            {
                PorderModel porderModel = new PorderModel();


                porderModel. OrderId = order.OrderId;
                porderModel.PDate = order.PDate;
                porderModel. PTime = order.PTime;
                porderModel.OrderCost = order.OrderCost;

              
                Domain.Model.Pizza pizza = repository.GetPizza(order.PizzaId);

                porderModel.PType = pizza.PType;
                porderModel.PSize = pizza.PSize;
                porderModel.PPrice = pizza.PPrice;
                porderModel.Crust = pizza.Crust;

                orderModels.Add(porderModel);
                   
            }

      
            return View(orderModels);
        }

        public IActionResult ViewOrdersAdmin()
        {
            double totalOrderCost = 0;

            List<Domain.Model.Porder> orders = repository.GetOrders();
            List<PorderModel> orderModels = new List<PorderModel>();

            TempData["orderCount"] = orders.Count;

            foreach (Domain.Model.Porder order in orders)
            {
                PorderModel porderModel = new PorderModel();


                porderModel.OrderId = order.OrderId;
                porderModel.PDate = order.PDate;
                porderModel.PTime = order.PTime;
                porderModel.OrderCost = order.OrderCost;


                totalOrderCost += Convert.ToDouble(order.OrderCost.Trim());

                Domain.Model.Puser user = repository.GetUser(order.PUserId);
           

                porderModel.FirstName = user.Firstname;
                porderModel.LastName = user.Lastname;

                Domain.Model.Pizza pizza = repository.GetPizza(order.PizzaId);

                porderModel.PType = pizza.PType;
                porderModel.PSize = pizza.PSize;
                porderModel.PPrice = pizza.PPrice;
                porderModel.Crust = pizza.Crust;

                orderModels.Add(porderModel);

            }

            TempData["totalCost"] = totalOrderCost;

            return View(orderModels);
        }


        public IActionResult Order(int pizzaId)
        {
            Domain.Model.Pizza pizza = repository.GetPizza(1);
            Domain.Model.Plocation location = repository.GetLocation(pizza.SLocationId);

            if (pizza != null)
            {
                orderModel = new PorderModel();


                orderModel.PDate = DateTime.Now.ToString("M/d/yyyy");
                orderModel.PTime = DateTime.Now.ToShortTimeString();
                orderModel.PType = pizza.PType;
                orderModel.PSize = pizza.PSize;
                orderModel.Crust = pizza.Crust;
                orderModel.PUserId = Convert.ToInt32(TempData["user"]);
                orderModel.PizzaId = pizza.PizzaId;
                orderModel.OrderCost = "57.67";
                orderModel.PPrice = pizza.PPrice;
                orderModel.CLocationId = location.LocationId;
                orderModel.Street = location.Street;
                orderModel.City = location.City;
                orderModel.PState = location.PState;
                orderModel.Zipcode = location.Zipcode;

                return View(orderModel);

            }

            return View();
        }

        public IActionResult OrderDetails()
        {
            PizzaModel pizzaModel = (PizzaModel)TempData["pizza"];
            PuserModel userModel = (PuserModel)TempData["user"];

            if (pizzaModel != null)
            {
                orderModel = new PorderModel();

                orderModel.PDate = DateTime.Now.ToString("M/d/yyyy");
                orderModel.PTime = DateTime.Now.ToShortTimeString();
                orderModel.PType = pizzaModel.PType;
                orderModel.PSize = pizzaModel.PSize;
                orderModel.Crust = pizzaModel.Crust;
                orderModel.PUserId = userModel.PUserId;
                orderModel.PizzaId = pizzaModel.PizzaId;
                orderModel.OrderCost = "57.67";
                orderModel.PPrice = pizzaModel.PPrice;
                orderModel.CLocationId = pizzaModel.SLocationId;
            }

            return Content(orderModel.PUserId + " ");
        }

    }
}
