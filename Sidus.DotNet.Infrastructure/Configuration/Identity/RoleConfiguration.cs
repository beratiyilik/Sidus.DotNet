using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sidus.DotNet.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sidus.DotNetFramework.Base.Constant;

namespace Sidus.DotNet.Infrastructure.Configuration.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role", "Identity");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.CreatedAt).ValueGeneratedOnAdd();

            builder.Property(m => m.LastModifiedAt).ValueGeneratedOnUpdate();

            builder.Property(m => m.State).HasDefaultValue<Sidus.DotNetFramework.Base.Enums.Enums.EntityState>(Sidus.DotNetFramework.Base.Enums.Enums.EntityState.Active);

            builder.Property(m => m.Version).IsRequired().IsRowVersion();

            builder.HasData(new Role()
            {
                Id = TableKeys.ADMIN_ROL_ID,
                Name = "admim",
                CreatedById = TableKeys.SYSTEM_USER_ID
            });
        }
    }
}
