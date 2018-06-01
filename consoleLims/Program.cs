using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
//using DomainModel.Concrete;
//using DomainModel.Entities;
//using DomainModel.Interfaces;
using Domain.Services;
using Application.Services;
using Application.Services.Interfaces;
using Application.Services.ViewModels;
using System.Reflection;
using Domain.Model.Entities;
using ClientAppLibrary;
namespace consoleLims
{
    class Program
    {
        public static ClientWebApi client;
        public static IUserService userService;
        static void Main(string[] args)
        {
            userService = new UserService();
            client = new ClientWebApi((u) => Console.WriteLine(u));
            while (true)
            {
                Console.WriteLine("Список команд:");
                Console.WriteLine("1. Создать учетную запись");
                Console.WriteLine("2. Вывести список пользователей");
                Console.WriteLine("4. Выход");
                Console.WriteLine("Введите команду:");
                int commandNum = Int32.Parse(Console.ReadLine());
                switch (commandNum)
                {

                    case 1:
                        CreateUser();
                        break;
                    case 2:
                        var users = client.GetUsers();
                        foreach(var a in users)
                        {
                            Console.WriteLine($"{a.Usrnam}");
                        }
                        break;
                    case 3:
                        ChangeUser();
                        break;
                    case 4:
                        Console.WriteLine("Нажмите клавишу для выхода...");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Неправильно введена команда");
                        break;

                }

                

            }
            Console.WriteLine("Конец");
            /*
            DirectConnectionAppServices services = new DirectConnectionAppServices();
            var Users = services.GetAllUsers();
            foreach (User u in Users)
            {
                Console.WriteLine($"{u.Usrnam}\t{u.Fullname}\t{u.Dept}");
            }
            Console.WriteLine("Я готов, а вы?");
            */
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
        public static void CreateUser()
        {
            ListOfUsers user = new ListOfUsers();
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            Type mytype = typeof(Application.Services.ViewModels.ListOfUsers);
            foreach (PropertyInfo p in mytype.GetProperties())
            {
                p.GetCustomAttribute(typeof(DisplayNameAttribute));
                Console.WriteLine($"Введите {p.Name}");
                string tmp = Console.ReadLine();
                keyValues.Add(p.Name, tmp);
                MethodInfo m = p.SetMethod;
                m.Invoke(user, new string[] { tmp });



            }
            Console.WriteLine($"{user.Usrnam}\t{user.Fullname}\t{user.Status}");
            userService.AddUser(new User()
            {
                Usrnam = user.Usrnam,
                Fullname = user.Fullname,
                Dept = "Test",
                Status = user.Status,
                JobDescription = "jobdescription"


            });
        }

        public static void ChangeUser()
        {
            Console.WriteLine("Введите имя пользователя:");
            string username = Console.ReadLine();
            User user = client.GetUserAsync(username);
            if (user==null)
            {
                Console.WriteLine("Пользователь {0} не найден!", username);
                return;
            }
            Console.WriteLine(user);
            Console.WriteLine($"{user.Usrnam}\t{user.Fullname}\t{user.Email}");
            /*
            Type mytype = typeof(Application.Services.ViewModels.ListOfUsers);
            foreach (PropertyInfo p in mytype.GetProperties())
            {
                p.GetCustomAttribute(typeof(DisplayNameAttribute));
                Console.WriteLine($"Введите {p.Name}");
                string tmp = Console.ReadLine();
                keyValues.Add(p.Name, tmp);
                MethodInfo m = p.SetMethod;
                m.Invoke(user, new string[] { tmp });



            }
            */
        }

        
    }


}
