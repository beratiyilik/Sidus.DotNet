using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sidus.DotNet.Core.Entities.Base;
using Sidus.DotNetFramework.Base.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNet.Infrastructure.Configuration.Base
{
    public abstract class BaseApplicaitonEntityTypeConfiguration<TEntity> : BaseEntityTypeConfiguration<TEntity, Guid> where TEntity : BaseApplicationEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
