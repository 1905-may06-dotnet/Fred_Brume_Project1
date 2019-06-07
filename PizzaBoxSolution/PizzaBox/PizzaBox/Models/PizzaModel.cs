using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Models
{
    public class PizzaModel : IValidatableObject
    {

        public PizzaModel()
        {
            PizzaToppings = new HashSet<PizzaToppingsModel>();
            Porder = new HashSet<PorderModel>();
            Toppings = new HashSet<ToppingsModel>();
        }

        public int PizzaId { get; set; }

        [DisplayName("Pizza Type")]
        public string PType { get; set; }

        [DisplayName("Pizza Price")]
        public string PPrice { get; set; }

        [DisplayName("Pizza Size")]
        public string PSize { get; set; }

        [DisplayName("Toppings")]
        public string ToppingList { get; set; }

        [DisplayName("Toppings")]
        public List<string>Toppingstring { get; set; }
     
        public string Crust { get; set; }
        public int SLocationId { get; set; }
   
        public virtual PlocationModel SLocation { get; set; }
        public virtual ICollection<PizzaToppingsModel> PizzaToppings { get; set; }
        public virtual ICollection<PorderModel> Porder { get; set; }
        public virtual ICollection<ToppingsModel> Toppings { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Toppingstring?.Count > 3)
            {
                yield return new ValidationResult("You are only allowed to choose 5 toppings", new[] { nameof(Toppingstring) });
            }
        }
    }
}
