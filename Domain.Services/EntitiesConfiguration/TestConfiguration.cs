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
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.ToTable("TESTS");
            builder.HasKey(x => x.Testno);
            //builder.Property(x => x.status).HasConversion(v => v.ToString(),
              //                              v => (Statuses)Enum.Parse(typeof(Statuses), v));
            //builder.Property(x=>x.JobDescription).
        }
    }
}
