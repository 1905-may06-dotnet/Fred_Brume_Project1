using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Domain.Model;

namespace PizzaBox.Data.Model
{
    public class Repository : IRepository
    {

        //Location
        public Domain.Model.Plocation GetLocation(int location_Id)
        {
            return GetLocations().Where(l => l.LocationId == location_Id).FirstOrDefault();
        }


        public List<Domain.Model.Plocation> GetLocations()
        {
            return Mapper.Map(DBinstance.Instance.Plocation).ToList();
        }

        public int InsertLocation(Domain.Model.Plocation location)
        {
            int i = 0;

            try
            {
                DBinstance.Instance.Add(location);
                i = DBinstance.Instance.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Insertion Gone Wrong, Pls Check your network:");
                Console.WriteLine();

            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't Insert LOCATION: ");
                Console.WriteLine(e);
                Console.WriteLine();
            }


            return i;
        }

        public void voidDeleteLocation(Plocation location)
        {

        }




        //Pizza
        public Domain.Model.Pizza GetPizza(int pizza_Id)
        {
            return GetPizzas().Where(r => r.PizzaId == pizza_Id).FirstOrDefault();
        }

        public List<Domain.Model.Pizza> GetDistinctPizzas()
        {
            return Mapper.Map(DBinstance.Instance.Pizza.GroupBy(a => a.PType)
                   .Select(g => g.First()))
                   .ToList();
        }

        public List<Domain.Model.Pizza> GetPizzas()
        {
            return Mapper.Map(DBinstance.Instance.Pizza).ToList();
        }

        public List<Domain.Model.Pizza> GetPizzasFromLocation(int location_id)
        {
            //if it is distinct by name, you can get an exception. This logic is not feasible
            return GetDistinctPizzas().Where(r => r.SLocationId == location_id).ToList();   
        }

        public List<Domain.Model.Pizza> GetPizzas(int location_id)
        {
            //if it is distinct by name, you can get an exception. This logic is not feasible
            return GetPizzas().Where(r => r.SLocationId == location_id).ToList();
        }

        public Domain.Model.Pizza GetPizzaByAttributes(string PType, string PSize, string Crust, int location_id)
        {
            return GetPizzas().Where(r => r.PType.ToLower().Equals(PType.ToLower())

               && r.PSize.ToLower().Equals(PSize.ToLower())
               && r.Crust.ToLower().Trim().Contains(Crust.ToLower())
               && r.SLocationId == location_id).FirstOrDefault();
        }




        //Toppings
        public List<Domain.Model.Toppings> GetToppings(int pizza_Id)
        {
           return GetToppings().Where(p => p.PizzaId == pizza_Id).ToList();
        }

        public Domain.Model.Toppings GetTopping(string topping)
        {
            return GetToppings().Where(p => p.TName == topping).FirstOrDefault();
        }

        public List<Domain.Model.Toppings> GetToppings()
        {
            return Mapper.Map(DBinstance.Instance.Toppings).ToList();
        }



        //Users
        public List<Domain.Model.Puser> GetUsers()
        {
            return Mapper.Map(DBinstance.Instance.Puser).ToList();
        }

        public Domain.Model.Puser GetUser(Domain.Model.Puser user)
        {
            return GetUsers().Where(u =>  u.Username == user.Username && u.PPassword == user.PPassword).FirstOrDefault();
        }

        public Domain.Model.Puser GetUser(int user)
        {
            return GetUsers().Where(u => u.PUserId == user).FirstOrDefault();
        }

        public Domain.Model.Employee GetEmployee(int user_id)
        {
            return GetEmployees().Where(e => e.PUserId == user_id).FirstOrDefault();
        }

        public List<Domain.Model.Employee> GetEmployees()
        {
            return Mapper.Map(DBinstance.Instance.Employee).ToList();
        }

       

      
        //Customers
        public List<Domain.Model.Customer> GetCustomers()
        {
            return Mapper.Map(DBinstance.Instance.Customer).ToList();
        }

        public Domain.Model.Customer GetCustomer(int user_Id)
        {
            return GetCustomers().Where(c=> c.PUserId == user_Id).FirstOrDefault();
        }


        public int AddUser(Domain.Model.Puser user)
        {
            int i = 0;
            try
            {

                DBinstance.Instance.Add(Mapper.Map(user));
                i = DBinstance.Instance.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Insertion Gone Wrong, Pls Check your network:");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't Insert USER: ");
                Console.WriteLine(e);
                Console.WriteLine();
            }

            return i;
        }


        //Order
        public int AddOrder(Domain.Model.Porder order)
        {
            int i = 0;
            try
            {

                DBinstance.Instance.Add(Mapper.Map(order));
                i = DBinstance.Instance.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Insertion Gone Wrong, Pls Check your network:");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't Insert USER: ");
                Console.WriteLine(e);
                Console.WriteLine();
            }

            return i;
        }

        

        public List<Domain.Model.Porder> GetOrders()
        {
            return Mapper.Map(DBinstance.Instance.Porder).ToList();
        }

        public List<Domain.Model.Porder> GetOrders(int user_Id)
        {
            return GetOrders().Where(o => o.PUserId == user_Id).ToList();
        }

        public int AddCustomer(Domain.Model.Customer customer)
        {

            int i = 0;
            try
            {
                DBinstance.Instance.Add(Mapper.Map(customer));
                i = DBinstance.Instance.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Insertion Gone Wrong, Pls Check your network:");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't Insert USER: " + e);
                Console.WriteLine(e);
                Console.WriteLine();
            }

            return i;
        }

        public int AddPizzaToppings(Domain.Model.PizzaToppings pizzaToppings)
        {

            int i = 0;
            try
            {
                DBinstance.Instance.Add(Mapper.Map(pizzaToppings));
                i = DBinstance.Instance.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Insertion Gone Wrong, Pls Check your network:");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't Insert PIZZA TOPPINGS: " + e);
                Console.WriteLine(e);
                Console.WriteLine();
            }

            return i;
        }

       
    }
}
