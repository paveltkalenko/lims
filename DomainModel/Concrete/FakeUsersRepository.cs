using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Interfaces;
using DomainModel.Entities;
namespace DomainModel.Concrete
{
    public class FakeUsersRepository : IGenericRepository<Users>
    {
        private static IEnumerable<Users> fakeUsers = new List<Users>
            {new Users { Usrnam = "TESTFAKE", Dept = "DEPT IS FAKE"} }.AsEnumerable();
        public void Create(Users item)
        {
            throw new NotImplementedException();
        }

        public Users FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> Get()
        {
            return fakeUsers;
        }

        public IEnumerable<Users> Get(Func<Users, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(Users item)
        {
            throw new NotImplementedException();
        }

        public void Update(Users item)
        {
            throw new NotImplementedException();
        }
    }
}
