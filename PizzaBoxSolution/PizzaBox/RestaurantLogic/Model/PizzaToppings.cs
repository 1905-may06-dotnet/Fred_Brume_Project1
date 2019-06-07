using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Model
{
    public partial class PizzaToppings
    {
        public int PTopId { get; set; }
        public int TopId { get; set; }
        public int PizzaId { get; set; }
        public int P_user_Id { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual Toppings Top { get; set; }
        public virtual Puser Puser { get; set; }
    }
}
