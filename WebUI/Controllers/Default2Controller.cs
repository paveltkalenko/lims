using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Model.Entities;
using Application.Services.Interfaces;
using Application.Services;
using Domain.Services;

namespace WebUI.Controllers
{
    [Route("api/d")]
    public class Default2Controller : ApiController
    {
        private readonly IUserService userService;
        UnitOfWork UnitOfWork;
        private Default2Controller()
        {
            UnitOfWork = new UnitOfWork();
            this.userService = new UserService(UnitOfWork);
        }
        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> users;

            users = userService.GetListOfAllUsers();

            return users;
        }

    }
}
