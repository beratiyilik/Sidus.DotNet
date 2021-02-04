using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sidus.DotNet.Core.Entities.System;
using Sidus.DotNet.Infrastructure.Configuration.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sidus.DotNet.Core.Enums.Enums;

namespace Sidus.DotNet.Infrastructure.Configuration.System
{
    public class ActionConfiguration : BaseApplicaitonEntityTypeConfiguration<Sidus.DotNet.Core.Entities.System.Action>
    {
        public override void Configure(EntityTypeBuilder<Sidus.DotNet.Core.Entities.System.Action> builder)
        {
            base.Configure(builder);

            builder.ToTable("Action", "System")
                .HasOne<Sidus.DotNet.Core.Entities.System.Action>(m => m.Parent)
                .WithMany(m => m.Childs)
                .HasForeignKey(m => m.ParentId);
            // .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.Type).IsRequired();

            builder.Property(m => m.Name).IsRequired();

            builder.Property(m => m.FullName).IsRequired();

            // builder.HasAlternateKey(a => new { a.FullName, a.Parameters });
        }
    }
}
