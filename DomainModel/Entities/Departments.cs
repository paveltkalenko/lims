using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities
{

    public partial class Departments
    {

        [Key]
        public string Dept { get; set; }
        public List<Users> Users { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return "Отдел - " + Dept;
        }
    }
}
