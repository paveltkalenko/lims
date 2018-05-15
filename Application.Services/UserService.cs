using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Interfaces;
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
        public void AddUser(String username, String fullname)
        {
            User u1 = new User() { Usrnam = username, Fullname = fullname, Dept = "test" };
            userRepository.Insert(u1);
            UnitOfWork.Save();
            
        }
        public IEnumerable<User> GetListOfActiveUsers()
        {
            return userRepository.GetAll();
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetListOfAllUsers()
        {
            return userRepository.GetAll();
            throw new NotImplementedException();
        }
    }
}
