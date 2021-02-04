using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sidus.DotNet.Core.Entities.Identity;
using Sidus.DotNetFramework.Base.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNet.Infrastructure.Configuration.Identity
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole", "Identity");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.CreatedAt).ValueGeneratedOnAdd();

            builder.Property(m => m.LastModifiedAt).ValueGeneratedOnUpdate();

            builder.Property(m => m.State).HasDefaultValue<Sidus.DotNetFramework.Base.Enums.Enums.EntityState>(Sidus.DotNetFramework.Base.Enums.Enums.EntityState.Active);

            builder.Property(m => m.Version).IsRequired().IsRowVersion();

            builder.HasData(new UserRole()
            {
                UserId = TableKeys.SYSTEM_USER_ID,
                RoleId = TableKeys.ADMIN_ROL_ID,
                CreatedById = TableKeys.SYSTEM_USER_ID
            });

            builder.HasOne<User>(m => m.User)
                .WithMany(m => m.Roles)
                .HasForeignKey(m => m.UserId);

            builder.HasOne<Role>(m => m.Role)
                .WithMany(m => m.UserRoles)
                .HasForeignKey(m => m.RoleId);

        }
    }
}
