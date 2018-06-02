using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Model.Entities;
namespace Domain.Services.EntitiesConfiguration
{
    public class FolderConfiguration : IEntityTypeConfiguration<Folder>
    {
        public void Configure(EntityTypeBuilder<Folder> builder)
        {
            builder.ToTable("FOLDERS");
            builder.HasKey(x => x.Folderno);
            //builder.Property(x => x.status).HasConversion(v => v.ToString(),
              //                              v => (Statuses)Enum.Parse(typeof(Statuses), v));
            //builder.Property(x=>x.JobDescription).
        }
    }
}
