using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Models
{
    public class EmployeeModel
    {
        public int EUserId { get; set; }
        public int PUserId { get; set; }
        public string Position { get; set; }

        public virtual PuserModel PUserModel { get; set; }
    }
}
