using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sidus.DotNet.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sidus.DotNetFramework.Base.Constant;
using static Sidus.DotNetFramework.Base.Enums.Enums;

namespace Sidus.DotNet.Infrastructure.Configuration.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "Identity");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.CreatedAt).ValueGeneratedOnAdd();

            builder.Property(m => m.LastModifiedAt).ValueGeneratedOnUpdate();

            builder.Property(m => m.State).HasDefaultValue<Sidus.DotNetFramework.Base.Enums.Enums.EntityState>(Sidus.DotNetFramework.Base.Enums.Enums.EntityState.Active);

            builder.Property(m => m.Version).IsRequired().IsRowVersion();

            builder.Property(m => m.EntityType).HasDefaultValue<EntityType>(EntityType.NaturalPerson);

            builder.HasData(new User()
            {
                Id = TableKeys.SYSTEM_USER_ID,
                FirstName = "System",
                LastName = "User",
                UserName = "systemuser",
                CreatedById = TableKeys.SYSTEM_USER_ID
            });
        }
    }
}
