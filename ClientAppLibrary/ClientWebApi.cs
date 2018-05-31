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
        public void UpdateUser(User user)
        {
            using (var client = new HttpClient())
            {
                //    var response = client.GetStringAsync(APP_PATH + $"/api/UsersApi/" + user.Usrnam);
                var jsonString = JsonConvert.SerializeObject(user);
                DebugOut("jsonString = " + jsonString);
                var httpContent = new StringContent(jsonString,Encoding.UTF8,"application/json");
                //httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                //var response = client.PostAsync(APP_PATH + $"/api/UsersApi/" + user.Usrnam, httpContent);
                DebugOut("httpContent = "+httpContent.ToString());
                //DebugOut(httpContent.ToString());
                client.PutAsync(APP_PATH + $"/api/UsersApi/" + user.Usrnam, httpContent);
                // client.PutAsJson
                // client.
                
                //  DebugOut(response.Result.ToString());
                // user = JsonConvert.DeserializeObject<User>(response.Result);

            }
            return;

        }


    }
}
