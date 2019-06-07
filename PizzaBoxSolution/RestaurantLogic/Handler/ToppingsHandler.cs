using PizzaBox.Domain.Model;
using System;
using System.Collections.Generic;


namespace PizzaBox.Domain.Handler
{
    public class ToppingsHandler
    {

        public static List<Toppings> GetDefaultToppings(List<Toppings> toppings)
        {
           List<Toppings> defaultToppings = new List<Toppings>();


           foreach (Toppings topping in toppings)
          {
              if (topping.TName.ToLower().Trim().Equals("default"))
                {
                    defaultToppings.Add(topping);
                }
           }

            return defaultToppings;


        }

        public static List<string> AddDefaultToChosenToppings(List<string> chosen, List<Toppings> defaultT)
        {
           List<Toppings> defs = GetDefaultToppings(defaultT);

           foreach (Toppings topping in defs)
            {
                chosen.Add(topping.TName);
            }

           return chosen;
        }

        public static bool validatetoppingscount(ref int maxtopping, int numtopping)
        {
            maxtopping = 100;
            return numtopping < 100 ? true : false;
        }

        public static double totaltoppingscost(List<Toppings> toppings)
        {
            double total = 0;

            foreach (Toppings topping in toppings)
            {
                total += Convert.ToDouble(topping.Cost);
            }

            return total;
        }
    }
}
