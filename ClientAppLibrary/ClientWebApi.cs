using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public IEnumerable<User> GetUsers()
        {
            DebugOut("Start connect");
            IEnumerable<User> users = null;
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(APP_PATH + "/api/Default");
                DebugOut(response.Result.ToString());
                users = JsonConvert.DeserializeObject<IEnumerable<User>>(response.Result);
            }
            return users;
        }

    }
}
