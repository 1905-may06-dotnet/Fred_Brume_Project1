using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Models;
using Lib = PizzaBox.Domain;

namespace PizzaBox.Controllers
{
    public class LoginController : Controller
    {
        private readonly Lib.IRepository repository;

        public LoginController(Lib.IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Login()
        {

            return View("Login");
        }

        public IActionResult SignUp()
        {

            return View("SignUp");
        }



        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ValidateLogin(Models.PuserModel user)
        {
            Lib.Model.Puser deUser = new Lib.Model.Puser()
            {
                Username = user.Username,
                PPassword = user.PPassword
            };

            try
            {
                deUser = repository.GetUser(deUser);
    
                if (deUser != null)
                {
                    TempData["user"] = deUser.PUserId;

                    Lib.Model.Employee employee = repository.GetEmployee(deUser.PUserId);

                    if(employee == null)
                    {
                        return RedirectToAction("CustomerMenu", "Home");
                    }else
                    {
                        return RedirectToAction("EmployeeMenu", "Home");
                    }

                }
            }
            catch (Exception e)
            {
         
            }

            return View("Login");
        }

      public IActionResult ValidateSignUp(IFormCollection collection, Models.PuserModel userModel)
        {
            Domain.Model.Plocation location = new Domain.Model.Plocation();
            Domain.Model.Puser user = new Domain.Model.Puser();

            try
            {
                location.Street = userModel.Street;
                location.City = userModel.City;
                location.PState = userModel.State;
                location.Zipcode = userModel.Zipcode;

                repository.InsertLocation(location);

                List<Domain.Model.Plocation> locations = repository.GetLocations();

                user.Firstname = userModel.Firstname;
                user.Lastname = userModel.Lastname;
                user.Username = userModel.Username;
                user.pPassword = userModel.PPassword;
                user.Email = userModel.Email;
                user.LocationId = locations [locations.Count-1].LocationId;

                repository.AddUser(user);

                return RedirectToAction(nameof(Login));

            }
            catch(Exception e)
            {
                return View();
            }

        }

        
    }
}