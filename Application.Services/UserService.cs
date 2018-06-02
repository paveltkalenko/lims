using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Application.Services.ViewModels;
using Domain.Model.Entities;
using Domain.Services;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> userRepository;
        private UnitOfWork UnitOfWork;
        public UserService(IRepository<User> rep)
        {
            userRepository = rep;
        }

        public UserService(UnitOfWork uof)
        {
            UnitOfWork = uof;
            userRepository = uof.Repository<User>();
        }

        public UserService()
        {
            UnitOfWork = new UnitOfWork();
            userRepository = UnitOfWork.Repository<User>();
        }
        public void AddUser(String username, String fullname)
        {
            if (username == null) throw new ArgumentNullException();
            User u1 = new User() { Usrnam = username, Fullname = fullname, Dept = "test" };
            userRepository.Insert(u1);
            UnitOfWork.Save();       
        }

        public void AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException();
            userRepository.Insert(user);
            UnitOfWork.Save();
        }

        public IEnumerable<User> GetListUsersByStatus(Statuses status)
        {
            return userRepository.GetAll();
            throw new NotImplementedException();
        }

        public void GetListOfAllUsers<T>(ref IEnumerable<T> x)
        {
            Console.WriteLine(typeof(T));
            throw new NotImplementedException();

        }

        public User GetUserDescription(String username)
        {
            return userRepository.Table().FirstOrDefault<User>(u => u.Usrnam == username);
        }



        IEnumerable<ListOfUsers> IUserService.GetListOfAllUsers()
        {
            return userRepository.Table().Select(u => new ListOfUsers()
            {
                Usrnam = u.Usrnam,
                Fullname = u.Fullname,
                Status = u.Status
            }).ToList();
            
        }

        public void UpdateUser(User user)
        {
            userRepository.Update(user);
            UnitOfWork.Save();
            return;
            throw new NotImplementedException();
        }
    }
}
