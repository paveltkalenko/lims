using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetListOfAllUsers();
        IEnumerable<User> GetListOfActiveUsers();
    }
}
