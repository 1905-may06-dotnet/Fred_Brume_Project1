using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Model
{
    public partial class Customer
    {
        public int CUserId { get; set; }
        public int PUserId { get; set; }

        public virtual Puser PUser { get; set; }
    }
}
