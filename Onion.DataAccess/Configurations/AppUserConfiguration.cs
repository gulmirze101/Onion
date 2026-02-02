using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.DataAccess.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        void IEntityTypeConfiguration<AppUser>.Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(256);
        }
    }
}
