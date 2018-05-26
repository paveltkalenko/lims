using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using DomainModel.Concrete;
//using DomainModel.Entities;
//using DomainModel.Interfaces;
using Domain.Services;
//using Application.Services;
//using Application.Services.Interfaces;
using Domain.Model.Entities;
//using ClientAppLibrary;
namespace consoleLims
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DirectConnectionAppServices services = new DirectConnectionAppServices();
            var Users = services.GetAllUsers();
            foreach (User u in Users)
            {
                Console.WriteLine($"{u.Usrnam}\t{u.Fullname}\t{u.Dept}");
            }
            Console.WriteLine("Я готов, а вы?");
            Console.ReadKey();
            /*
            ClientWebApi webApi = new ClientWebApi((x) => Console.WriteLine(x));
            var users = webApi.GetUsers();
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Usrnam}\t{u.Fullname}\t{u.Dept}");
            }
            */

            Console.ReadKey();    
            /*
            UnitOfWork UnitOfWork = new UnitOfWork();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
            */
        }
        
    }


}
