
using PizzaBox.Domain.Model;
using PizzaBox.Domain.Handler;
using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Handler
{
    public class OrderHandler
    {
           
        public static double GetOrderCost(double pizzaCost, List<Toppings> toppings)
        {
            double topCost = 0;
            foreach(Toppings top in toppings)
            {
                topCost += Convert.ToDouble(top.Cost.Trim());
            }

            return topCost += pizzaCost;

        }

        public static bool validateCurrentCost(double currentCost)
        {
           return currentCost <= 5000 ? true : false;
        }

        public static bool CheckOrderDateTime(List<Porder> orders, Plocation location, Puser user)
        {
         
            for(int i=orders.Count -1; i >= 0; i--)
           {
                if (orders[i].PUserId == user.PUserId)  //Extract the latest Order by the user
               {
                    DateTime now = DateTime.Now;
                    DateTime datetime = DateTime.Parse(orders[i].PDate + " " + orders[i].PTime);

                    if (orders[i].CLocationId != location.LocationId) //Checks NOT Location
                   {
                       if ((now - datetime).TotalHours <= 24) //Checks within 24 hours period
                        {
                           return false;
                        }
                   }

                    if (orders[i].CLocationId == location.LocationId) //Checks YES Location
                   {
                       if ((now - datetime).TotalHours <= 2) //Checks within 2 hours period
                       {
                           return false;
                       }
                   }

                }
            }

            return true;

       }

     }
}
