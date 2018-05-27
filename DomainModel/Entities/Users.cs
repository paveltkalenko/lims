using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DomainModel.Entities
{
    /*
    public partial class Users
    {
        public int Id { get; set; }
        
        public int? Age { get; set; }

        [Required,MaxLength(48)]
        public string Name { get; set; }

        [Required,MaxLength(6)]
        public string Sex { get; set; }
    }
    */
    public partial class Users
    {
        [Key]
        public string Usrnam { get; set; }

        public string Dept { get; set; }

       // [ForeignKey("Dept")]
        public virtual Departments Departments { get; set; }

    }
}
