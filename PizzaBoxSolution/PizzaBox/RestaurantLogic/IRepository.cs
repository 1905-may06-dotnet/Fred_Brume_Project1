using PizzaBox.Domain.Model;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public interface IRepository
    {
        List<Plocation> GetLocations();
        int InsertLocation(Plocation location);
        Plocation GetLocation(int location_Id);
        Pizza GetPizza(int pizza_Id);
        List<Pizza> GetPizzas(int LocationId);
        Pizza GetPizzaByAttributes(string PType, string PSize, string Crust, int location_id);
        List<Pizza> GetPizzasFromLocation(int location_id);
        Toppings GetTopping(string topping);
        List<Toppings> GetToppings(int pizza_Id);
        List<Toppings> GetToppings();
        List<Puser> GetUsers();
        Puser GetUser(Puser user);
        Puser GetUser(int user);
        Employee GetEmployee(int user_id);
        List<Employee> GetEmployees();
        int AddUser(Puser user);
        int AddOrder(Porder order);
        List<Porder> GetOrders(int user_Id);
        List<Porder> GetOrders();
        int AddPizzaToppings(PizzaToppings pizzaToppings);
        int AddCustomer(Customer customer);
        Customer GetCustomer(int user_Id);
        List<Customer> GetCustomers();
    }
}
