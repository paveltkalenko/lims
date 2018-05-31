using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Model.Entities;
using Application.Services.Interfaces;
using Application.Services.ViewModels;
using Application.Services;
//using Domain.Services;

namespace WebUI.Controllers.api
{

    public class UsersApiController : ApiController
    {
        
        private readonly IUserService userService;
       // UnitOfWork UnitOfWork;
        private UsersApiController()
        {
        //    UnitOfWork = new UnitOfWork();
            this.userService = new UserService(/*UnitOfWork*/);
        }
        public IEnumerable<ListOfUsers> GetAllUsers()
        {
            /* IEnumerable<User> users = new List<User>
             {
                 new User{Usrnam="test", Fullname="tkalenko",Dept="nodept"},
                 new User{Usrnam="superuser", Fullname="tkalenko",Dept="nodept"}
             };*/

            IEnumerable<ListOfUsers> users = userService.GetListOfAllUsers();

            return users;
        }

    }
}
