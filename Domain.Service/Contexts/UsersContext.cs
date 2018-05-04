using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Services.EntitiesConfiguration;
using Domain.Model.Entities;

namespace Domain.Services.Contexts
{
    public class UsersContext : ApplicationBaseContext
    {
         public virtual DbSet<User> Users { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
                modelBuilder.ApplyConfiguration(new UserConfiguration());
         }

        
    }
}
