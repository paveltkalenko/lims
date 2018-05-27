using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DomainModel.Entities;

namespace DomainModel.Concrete
{
    public class LaboratoryContext : DbContext
    {
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(local)\sqlexpress; Database=v11_GEDEON_TEST_DATA; Trusted_Connection=True;");
            }
        }
    }
}
