using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Entities;

namespace App.Infra.Data.SqlServer.Ef.Configuration
{
    public class DutyConfiguration : IEntityTypeConfiguration<Duty>
    {
        public void Configure(EntityTypeBuilder<Duty> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Duty");
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(4000);
            builder.HasOne(x => x.User)
                  .WithMany(x => x.Duties)
                  .HasForeignKey(x => x.UserId)
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
