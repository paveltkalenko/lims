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
        public IEnumerable<ListOfUsers> GetUsers()
        {
            DebugOut("Start connect");
            IEnumerable<ListOfUsers> users = null;
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(APP_PATH + "/api/UsersApi");
                DebugOut(response.Result.ToString());
                users = JsonConvert.DeserializeObject<IEnumerable<ListOfUsers>>(response.Result);
            }
            return users;
        }

        public User GetUser(string username)
        {
            User user;
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(APP_PATH + "/api/UsersApi/"+username);
                DebugOut(response.Result.ToString());
                user = JsonConvert.DeserializeObject<User>(response.Result);
                
            }
            return user;

        }
        public async Task<HttpResponseMessage> UpdateUserAsync(User user)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(user);
                DebugOut("jsonString = " + jsonString);
                var httpContent = new StringContent(jsonString,Encoding.UTF8,"application/json");

                DebugOut("httpContent = "+httpContent.ToString());
                response = await client.PutAsync(APP_PATH + $"/api/UsersApi/" + user.Usrnam, httpContent);
                DebugOut($"Task PutAsync Done with code - {response.StatusCode}");


            }
            return response;

        }


    }
}
