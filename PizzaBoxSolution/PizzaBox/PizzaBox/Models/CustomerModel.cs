using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Models
{
    public class CustomerModel
    {
        public int CUserId { get; set; }
        public int PUserId { get; set; }

        public virtual PuserModel PUser { get; set; }
    }
}
