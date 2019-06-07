using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Models
{
    public class PorderModel
    {
        public int OrderId { get; set; }
        [DisplayName("Order Date")]
        public string PDate { get; set; }

        [DisplayName("Order Time")]
        public string PTime { get; set; }
        public string OrderCost { get; set; }
        public int PizzaId { get; set; }

        [DisplayName("Pizza Type")]
        public string PType { get; set; }

        [DisplayName("Pizza Price")]
        public string PPrice { get; set; }

        [DisplayName("Pizza Size")]
        public string PSize { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Crust { get; set; }
        public int PUserId { get; set; }
        public int CLocationId { get; set; }

        public string Street { get; set; }
        public string City { get; set; }

        [DisplayName("State")]
        public string PState { get; set; }
        public string Zipcode { get; set; }

        public virtual PlocationModel CLocation { get; set; }
        public virtual PuserModel PUser { get; set; }
        public virtual PizzaModel Pizza { get; set; }
    }
}
