using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using DomainModel.Concrete;
//using DomainModel.Entities;
//using DomainModel.Interfaces;
using Domain.Services;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Model.Entities;
namespace consoleLims
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                     IGenericRepository<Users> fakeUsers = new FakeUsersRepository();
                     foreach (Users u in fakeUsers.Get())
                     {
                         Console.WriteLine($"{u.Usrnam}\t{u.Dept}");
                     }

                     Console.ReadKey();
                     */

            /*
            using (LaboratoryTestContext db = new LaboratoryTestContext())
            {
                /*
                List<Departments> dept = db.Departments.ToList();
                foreach (Departments d in dept)
                {
                    Console.WriteLine($"{d.Dept}");
                }
                
                List<Users> users = db.Users.ToList();
                foreach (Users user in users)
                {
                    Console.WriteLine($"{user.Usrnam}");
                    //Console.WriteLine($"{user.DEPT?.Dept??"fdfs"}");
                    //  Console.WriteLine($"{user.usrnam}|\t{user?.Dept??"без отдела"}|\t{user.DEPT2}|\t{user.DEPT2?.Name??"без имени отдела"}|\t{user.DEPT2?.Dept??"без отдела"}");
                }
                
            }
            */
            

            using (BaseRepository<User> repository = new BaseRepository<User>())
            {
                IUserService us = new UserService(repository);

                List<User> users = us.GetListOfAllUsers().ToList();
                foreach (User user in users)
                {
                    Console.WriteLine($"{user.Usrnam}\t{user.Fullname}");
                }
            }
            Console.ReadKey();
            
            
        }
    }
}
