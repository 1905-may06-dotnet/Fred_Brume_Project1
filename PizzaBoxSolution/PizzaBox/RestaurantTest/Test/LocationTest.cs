using PizzaBox.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;



namespace PizzaBox.Testing.Test
{
    public class LocationTest
    { 
    
        [Fact]
       public void Location()
       {
            Plocation location = new Plocation();

           location.PState = "Brooklyn";
           location.Street = "West 34 columbus Ave";
           location.Zipcode = "11232";

           Assert.NotNull(location.City);
           Assert.NotNull(location.Street);
           Assert.NotNull(location.Zipcode);
           Assert.Empty(location.City);
       }


   }
}
