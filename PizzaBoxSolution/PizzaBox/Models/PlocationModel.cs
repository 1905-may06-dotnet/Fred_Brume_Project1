
using System.Collections.Generic;
using System.ComponentModel;

namespace PizzaBox.Models
{
    public class PlocationModel
    {

        public PlocationModel()
        {
            Pizza = new HashSet<PizzaModel>();
            Porder = new HashSet<PorderModel>();
            Puser = new HashSet<PuserModel>();
        }

        public int LocationId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        [DisplayName("State")]
        public string PState { get; set; }
        public string Zipcode { get; set; }

        public virtual ICollection<PizzaModel> Pizza { get; set; }
        public virtual ICollection<PorderModel> Porder { get; set; }
        public virtual ICollection<PuserModel> Puser { get; set; }
    }
}
