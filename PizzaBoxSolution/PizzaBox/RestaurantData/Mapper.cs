using PizzaBox.Data.Model;
using System.Collections.Generic;
using System.Linq;


namespace PizzaBox.Data
{
    public static class Mapper
    {

        public static Domain.Model.Plocation Map(Plocation location) => new Domain.Model.Plocation
        {
            LocationId = location.LocationId,
            Street = location.Street,
            City = location.City,
            PState = location.PState,
            Zipcode = location.Zipcode

        };

        public static Plocation Map(Domain.Model.Plocation location) => new Plocation
        {
            LocationId = location.LocationId,
            Street = location.Street,
            City = location.City,
            PState = location.PState,
            Zipcode = location.Zipcode

        };


        public static Domain.Model.Pizza Map(Pizza pizza) => new Domain.Model.Pizza
        {
            PizzaId = pizza.PizzaId,
            PType = pizza.PType,
            PPrice = pizza.PPrice,
            PSize = pizza.PSize,
            Crust = pizza.Crust,
            SLocationId = pizza.SLocationId
        };

        public static Pizza Map(Domain.Model.Pizza pizza) => new Pizza
        {
            PType = pizza.PType,
            PPrice = pizza.PPrice,
            PSize = pizza.PSize,
            Crust = pizza.Crust,
            SLocationId = pizza.SLocationId
        };

        public static Domain.Model.Toppings Map(Toppings topping) => new Domain.Model.Toppings
        {
            TopId = topping.TopId,
            TName = topping.TName,
            Cost = topping.Cost,
            T_Type = topping.T_Type,
            PizzaId = topping.PizzaId
        };

        public static Toppings Map(Domain.Model.Toppings topping) => new Toppings
        {
            TopId = topping.TopId,
            TName = topping.TName,
            Cost = topping.Cost,
            T_Type = topping.T_Type,
            PizzaId = topping.PizzaId
        };

        public static PizzaToppings Map(Domain.Model.PizzaToppings topping) => new PizzaToppings
        {
            PTopId = topping.PTopId,
            TopId = topping.TopId,
            P_user_Id = topping.P_user_Id,
            PizzaId = topping.PizzaId
        };

        public static Domain.Model.PizzaToppings Map(PizzaToppings topping) => new Domain.Model.PizzaToppings
        {
            PTopId = topping.PTopId,
            TopId = topping.TopId,
            P_user_Id = topping.P_user_Id,
            PizzaId = topping.PizzaId
        };




        public static Domain.Model.Porder Map(Porder order) => new Domain.Model.Porder
        {
            OrderId = order.OrderId,
            PDate = order.PDate,
            PTime = order.PTime,
            OrderCost = order.OrderCost,
            PizzaId = order.PizzaId,
            PUserId = order.PUserId,
            CLocationId = order.CLocationId


        };

        public static Porder Map(Domain.Model.Porder order) => new Porder
        {
            OrderId = order.OrderId,
            PDate = order.PDate,
            PTime = order.PTime,
            OrderCost = order.OrderCost,
            PizzaId = order.PizzaId,
            PUserId = order.PUserId,
            CLocationId = order.CLocationId
        };


        public static Domain.Model.Puser Map(Puser user) => new Domain.Model.Puser
        {
            PUserId = user.PUserId,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Username = user.Username,
            PPassword = user.PPassword,
            Email = user.Email,
            LocationId = user.LocationId
        };

        public static Puser Map(Domain.Model.Puser user) => new Puser
        {
            PUserId = user.PUserId,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Username = user.Username,
            PPassword = user.PPassword,
            Email = user.Email,
            LocationId = user.LocationId
        };

        public static Employee Map(Domain.Model.Employee employee) => new Employee
        {
            EUserId = employee.EUserId,
            Position = employee.Position,
            PUserId = employee.PUserId
        };

        public static Domain.Model.Employee Map(Employee employee) => new Domain.Model.Employee
        {
            EUserId = employee.EUserId,
            Position = employee.Position,
            PUserId = employee.PUserId
        };

        public static Customer Map(Domain.Model.Customer customer) => new Customer
        {
            CUserId = customer.CUserId,
            PUserId = customer.PUserId
        };

        public static Domain.Model.Customer Map(Customer customer) => new Domain.Model.Customer
        {
            CUserId = customer.CUserId,
            PUserId = customer.PUserId
        };

        public static IEnumerable<Plocation> Map(IEnumerable<Domain.Model.Plocation> locations) => locations.Select(Map);
        public static IEnumerable<Domain.Model.Plocation> Map(IEnumerable<Plocation> locations) => locations.Select(Map);
        public static IEnumerable<Pizza> Map(IEnumerable<Domain.Model.Pizza> pizzas) => pizzas.Select(Map);
        public static IEnumerable<Domain.Model.Pizza> Map(IEnumerable<Pizza> pizzas) => pizzas.Select(Map);
        public static IEnumerable<Toppings> Map(IEnumerable<Domain.Model.Toppings> toppings) => toppings.Select(Map);
        public static IEnumerable<Domain.Model.Toppings> Map(IEnumerable<Toppings> toppings) => toppings.Select(Map);
        public static IEnumerable<Porder> Map(IEnumerable<Domain.Model.Porder> orders) => orders.Select(Map);
        public static IEnumerable<Domain.Model.Porder> Map(IEnumerable<Porder> orders) => orders.Select(Map);
        public static IEnumerable<Puser> Map(IEnumerable<Domain.Model.Puser> users) => users.Select(Map);
        public static IEnumerable<Domain.Model.Puser> Map(IEnumerable<Puser> users) => users.Select(Map);
        public static IEnumerable<Domain.Model.Employee> Map(IEnumerable<Employee> employees) => employees.Select(Map);
        public static IEnumerable<Employee> Map(IEnumerable<Domain.Model.Employee> employees) => employees.Select(Map);
        public static IEnumerable<Customer> Map(IEnumerable<Domain.Model.Customer> customers) => customers.Select(Map);
        public static IEnumerable<Domain.Model.Customer> Map(IEnumerable<Customer> customers) => customers.Select(Map);
        public static IEnumerable<PizzaToppings> Map(IEnumerable<Domain.Model.PizzaToppings> pizzaToppings) => pizzaToppings.Select(Map);
        public static IEnumerable<Domain.Model.PizzaToppings> Map(IEnumerable<PizzaToppings> pizzaToppings) => pizzaToppings.Select(Map);



    }
}

