using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Configuration
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.Property(a => a.Title).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Description).HasColumnType("ntext").IsRequired();
            builder.Property(a => a.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
