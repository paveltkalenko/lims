using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Model.Entities;
using Domain.Services.EntitiesConfiguration;
using System.Configuration;

namespace Domain.Services
{
    public class LaboratoryTestContext : ApplicationBaseContext
    {

        public virtual DbSet<User> Users {get;set;}
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }


}

