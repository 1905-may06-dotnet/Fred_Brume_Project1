using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Models
{
    public class PizzaToppingsModel
    {
        public int PTopId { get; set; }
        public int TopId { get; set; }
        public int PizzaId { get; set; }
        public int P_user_Id { get; set; }

        public virtual PuserModel Puser { get; set; }
        public virtual PizzaModel Pizza { get; set; }
        public virtual ToppingsModel Top { get; set; }
    }
}
