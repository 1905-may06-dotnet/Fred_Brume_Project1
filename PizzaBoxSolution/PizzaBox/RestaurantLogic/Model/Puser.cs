using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Model
{
    public partial class Puser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        private string username;
        public string pPassword;
        public string Email { get; set; }
        public int LocationId { get; set; }

        public Puser()
        {
            Customer = new HashSet<Customer>();
            Employee = new HashSet<Employee>();
            Porder = new HashSet<Porder>();
        }

        public int PUserId { get; set; }

        //public string Firstname
        //{
        //    get => firstName; set
        //    {
        //        if (String.IsNullOrEmpty(value))
        //        {
        //            throw new ArgumentException("firstName cant be empty");
        //        }

        //        firstName = value;
        //    }
        //}

        //public string LastName
        //{
        //    get => lastName; set
        //    {
        //        if (String.IsNullOrEmpty(value))
        //        {
        //            throw new ArgumentException("firstName cant be empty");
        //        }

        //        lastName = value;
        //    }
        //}

        public string Username
        {
            get => username; set
            {
                if (String.IsNullOrEmpty(value))
                {
                 //   throw new ArgumentException("Username cant be empty");
                }

                username = value;
            }
        }

        public string PPassword
        {
            get => pPassword; set
            {
                if (String.IsNullOrEmpty(value))
                {
                    //throw new ArgumentException("Password cant be empty");
                }

                pPassword = value;
            }
        }


        public virtual Plocation Location { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Porder> Porder { get; set; }
    }
}
