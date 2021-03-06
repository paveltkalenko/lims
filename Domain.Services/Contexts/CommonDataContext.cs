﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services;
using Domain.Services.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using Domain.Model.Entities;

namespace Domain.Services.Contexts
{
    /// <summary>
    /// Контекст c настройками таблиц
    /// </summary>
    public class CommonDataContext : ApplicationBaseContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
          //  modelBuilder.Entity<User>().Property(e=>e.status).
        }
    }
}
