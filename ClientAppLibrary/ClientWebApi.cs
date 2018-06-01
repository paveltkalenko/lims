using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.ViewModels;
using Domain.Model.Entities;
using System.Net.Http;
using Newtonsoft.Json;
namespace ClientAppLibrary
{
    public class ClientWebApi
    {
        private const string APP_PATH = "http://localhost:55010";
        Action<string> DebugOut;
        public ClientWebApi(Action<string> DebugAction)
        {
            DebugOut = DebugAction;
        }
        public async Task<IEnumerable<ListOfUsers>> GetUsersAsync()
        {
            DebugOut("Start connect");
            IEnumerable<ListOfUsers> users = null;
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(APP_PATH + "/api/UsersApi");
                users = JsonConvert.DeserializeObject<IEnumerable<ListOfUsers>>(response);
            }
            return users;
        }
        public async Task<User> GetUserAsync(string username)
        {
            User user;
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(APP_PATH + "/api/UsersApi/"+username);
                user = JsonConvert.DeserializeObject<User>(response);       
            }
            return user;

        }
        public async Task<HttpResponseMessage> UpdateUserAsync(User user)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(user);
                var httpContent = new StringContent(jsonString,Encoding.UTF8,"application/json");
                response = await client.PutAsync(APP_PATH + $"/api/UsersApi/" + user.Usrnam, httpContent);
            }
            return response;

        }


    }
}
