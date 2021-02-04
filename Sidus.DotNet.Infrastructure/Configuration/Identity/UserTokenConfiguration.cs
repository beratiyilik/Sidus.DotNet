using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sidus.DotNet.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNet.Infrastructure.Configuration.Identity
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("UserToken", "Identity");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.CreatedAt).ValueGeneratedOnAdd();

            builder.Property(m => m.LastModifiedAt).ValueGeneratedOnUpdate();

            builder.Property(m => m.State).HasDefaultValue<Sidus.DotNetFramework.Base.Enums.Enums.EntityState>(Sidus.DotNetFramework.Base.Enums.Enums.EntityState.Active);

            builder.Property(m => m.Version).IsRequired().IsRowVersion();

            builder.HasOne<User>(m => m.User)
                .WithMany(m => m.Tokens)
                .HasForeignKey(m => m.UserId);
        }
    }
}
