using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.Services.ViewModels;
using Application.Services;
using Domain.Model.Entities;
namespace WebUI.Controllers.api
{
    [Produces("application/json")]
    [Route("api/UsersApi")]
    public class UsersApiController : Controller
    {
        
        private readonly IUserService userService;
        public UsersApiController()
        {
            this.userService = new UserService();
        }
        


        // GET: api/UsersApi
        [HttpGet]
       /* public IEnumerable<ListOfUsers> Get()
        {
            IEnumerable<ListOfUsers> users = userService.GetListOfAllUsers();
            return users;
        }
        */
        public IActionResult Get()
        {
            IEnumerable<ListOfUsers> users = userService.GetListOfAllUsers();
            return new ObjectResult(users);
        }

        // GET: api/UsersApi/5
        [HttpGet("{username}", Name = "Get")]
        public IActionResult GetDescription(string username)
        {
            return new ObjectResult(userService.GetUserDescription(username));
        }
        
        // POST: api/UsersApi
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/UsersApi/5
        [HttpPut("{username}")]
        public void Put(string username, [FromBody]User user)
        {
            if (user == null)
            {
                StatusCode(404);
                return;
            }
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
           //HttpR
             userService.UpdateUser(user);
            // */
          //  HttpResponseException();

           // throw new 
            Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
