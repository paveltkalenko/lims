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

        public UsersController(/*IUserService userService*/)
        {
            //this.userService = userService;

            this.userService = new UserService(new BaseRepository<User>());
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