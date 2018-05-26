using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Services;
using Domain.Model.Entities;

namespace consoleLims
{
    public class DirectConnectionAppServices
    {
        private readonly IUserService userService;
        UnitOfWork UnitOfWork;
        private IRepository<User> userRepository;
        
        public DirectConnectionAppServices()
        {
            UnitOfWork = new UnitOfWork();
            userRepository = UnitOfWork.Repository<User>();
            
            this.userService = new UserService(UnitOfWork);
        }
        
        public IEnumerable<User> GetAllUsers()
        {
            
            IEnumerable<User> users = userRepository.GetAll();
            
            return users;
        }
        
    }
}
