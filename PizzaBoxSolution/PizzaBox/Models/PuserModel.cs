using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Models
{
    public class PuserModel
    {
        public PuserModel()
        {
            Customer = new HashSet<CustomerModel>();
            Employee = new HashSet<EmployeeModel>();
            Porder = new HashSet<PorderModel>();
        }

        public int PUserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [DisplayName ("Username")]
        [Required(ErrorMessage = "User Name cannot be blank")]
        [StringLength(30, ErrorMessage = "User Name should be maximun 30 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        [StringLength(20, ErrorMessage = "Password should be maximun 30 characters")]
        [DisplayName("Password")]
        public string PPassword { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [StringLength(30, ErrorMessage = "Email should be maximun 30 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Street cannot be blank")]
        [StringLength(40, ErrorMessage = "Street should be maximun 30 characters")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City cannot be blank")]
        [StringLength(15, ErrorMessage = "City should be maximun 30 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State cannot be blank")]
        [StringLength(15, ErrorMessage = "State should be maximun 30 characters")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zipcode cannot be blank")]
        [StringLength(6, ErrorMessage = "Zipcode should be maximun 30 characters")]
        public string Zipcode { get; set; }
        public int LocationId { get; set; }

        public virtual PlocationModel Location { get; set; }
        public virtual ICollection<CustomerModel> Customer { get; set; }
        public virtual ICollection<EmployeeModel> Employee { get; set; }
        public virtual ICollection<PorderModel> Porder { get; set; }
    }

    }
