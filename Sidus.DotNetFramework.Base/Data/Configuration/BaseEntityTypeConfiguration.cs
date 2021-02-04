using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sidus.DotNetFramework.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Data.Configuration
{
    public abstract class BaseEntityTypeConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.CreatedAt).ValueGeneratedOnAdd();

            builder.Property(m => m.LastModifiedAt).ValueGeneratedOnUpdate();

            builder.Property(m => m.State).IsRequired().HasDefaultValue<Sidus.DotNetFramework.Base.Enums.Enums.EntityState>(Sidus.DotNetFramework.Base.Enums.Enums.EntityState.Active);

            builder.Property(m => m.Version).IsRequired().IsRowVersion();
        }
    }
}
