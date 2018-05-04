using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Domain.Services
{
    public class ApplicationBaseContext : DbContext
    {
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
