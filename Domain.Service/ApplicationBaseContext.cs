using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Domain.Services.EntitiesConfiguration;

namespace Domain.Services
{
    /// <summary>
    /// Контекст данных с основными настройками
    /// </summary>
    public class ApplicationBaseContext : DbContext
    {
        public ApplicationBaseContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
          
                    var connectionString = ConfigurationManager.ConnectionStrings["dataConnection"].ConnectionString;
                    optionsBuilder.UseSqlServer(connectionString);
   
            }
        }


    }
}
