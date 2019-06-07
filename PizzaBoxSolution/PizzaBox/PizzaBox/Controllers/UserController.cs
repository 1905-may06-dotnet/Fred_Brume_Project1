using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Model;
using PizzaBox.Models;
using Lib = PizzaBox.Domain;

namespace PizzaBox.Controllers
{
    public class UserController : Controller
    {
        private readonly Lib.IRepository repository;

        public UserController(Lib.IRepository repository)
        {
            this.repository = repository;
        }


        public IActionResult ViewUsers()
        {
            List<Puser> users = repository.GetUsers();
            List<PuserModel> userModels = new List<PuserModel>();

            foreach (Puser user in users)
            {
                PuserModel model = new PuserModel();

                model.PUserId = user.PUserId;
                model.Firstname = user.Firstname;
                model.Lastname = user.Lastname;
                model.Username = user.Username;
                model.PPassword = user.PPassword;

                userModels.Add(model);
            }


        return View(userModels);
        }
    }
}