using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Application.Services.ViewModels;
namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<ListOfUsers> GetListOfAllUsers();
        IEnumerable<User> GetListUsersByStatus(Statuses status);
        User GetUserDescription(User user);
        
        void AddUser(String username, String fullname);
        void AddUser(User user);
        // void AddUser(User user);
    }
}
