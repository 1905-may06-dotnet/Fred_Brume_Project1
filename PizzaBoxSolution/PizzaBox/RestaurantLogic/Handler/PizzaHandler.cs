

using System;
using System.Collections.Generic;
using PizzaBox.Domain.Model;

namespace PizzaBox.Domain.Model
{
    public class PizzaHandler
    {

  
        public static bool validatePizzaCount(ref int maxPizza, int numPizza)
        {
            maxPizza = 100;
           return numPizza < 100 ? true : false;
        }

    }
}
