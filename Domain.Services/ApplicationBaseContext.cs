using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                base.OnConfiguring(optionsBuilder);
                //optionsBuilder.UseSqlServer()
                /*  IConfiguration conf = new ConfigurationBuilder()
                      .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                      .AddJsonFile("appsettings.json")
                      .Build();*/
             //    var connectionString = "Data Source=(local)\\sqlexpress;Initial Catalog=v11_GEDEON_TEST_DATA; Integrated Security = True";//conf.GetConnectionString("dataConnection");
                var connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=LIMS_DATA3; Integrated Security = True";
                                                                                                                                          //     var connectionString = ConfigurationManager.ConnectionStrings["dataConnection"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
   
            }
        }


    }
}
