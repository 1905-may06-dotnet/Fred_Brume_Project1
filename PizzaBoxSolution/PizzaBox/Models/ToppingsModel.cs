using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PizzaBox.Models
{
    public class ToppingsModel
    {
        public ToppingsModel()
        {
            PizzaToppings = new HashSet<PizzaToppingsModel>();
        }

        public int TopId { get; set; }

        [DisplayName("Topping Name")]
        public string TName { get; set; }
        public string Cost { get; set; }
        public string T_Type { get; set; }
        public int PizzaId { get; set; }

        public virtual PizzaModel Pizza { get; set; }
        public virtual ICollection<PizzaToppingsModel> PizzaToppings { get; set; }
    }
}
