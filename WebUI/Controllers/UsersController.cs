using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Services.Interfaces;
using Application.Services;
using Domain.Model.Entities;
using Domain.Services;
namespace WebUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        UnitOfWork UnitOfWork;
        public UsersController(/*IUserService userService*/)
        {
            //this.userService = userService;
            UnitOfWork = new UnitOfWork();
            this.userService = new UserService(UnitOfWork);
        }

        // GET: Users
        public ActionResult Index()
        {
            IEnumerable<User> users;

            users = userService.GetListOfAllUsers();

            return View(users);
        }
    }
}