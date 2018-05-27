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
            User u1 = new User() { Usrnam = username, Fullname = fullname, Dept = "test" };
            userRepository.Insert(u1);
            UnitOfWork.Save();
            
        }
        public void AddUser(User user)
        {
            
            userRepository.Insert(user);
            UnitOfWork.Save();

        }
        public IEnumerable<User> GetListUsersByStatus(Statuses status)
        {
            return userRepository.GetAll();
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetListOfAllUsers()
        {
            return userRepository.GetAll();
            throw new NotImplementedException();
        }

        public User GetUserDescription(User user)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ListOfUsers> IUserService.GetListOfAllUsers()
        {
            return userRepository.Table().Select(u => new ListOfUsers()
                {
                    Usrnam = u.Usrnam,
                    Fullname = u.Usrnam,
                    Status = "Active"
                }).ToList();
            
        }
    }
}
