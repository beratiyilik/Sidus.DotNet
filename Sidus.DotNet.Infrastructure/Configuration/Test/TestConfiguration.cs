using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sidus.DotNetFramework.Base.Constant;
using Sidus.DotNet.Infrastructure.Configuration.Base;

namespace Sidus.DotNet.Infrastructure.Configuration.Test
{
    public class TestConfiguration : BaseApplicaitonEntityTypeConfiguration<Sidus.DotNet.Core.Entities.Test.Test>
    {
        public override void Configure(EntityTypeBuilder<Core.Entities.Test.Test> builder)
        {
            base.Configure(builder);

            builder.ToTable("Test", "Test")
                .HasKey(m => m.Id);

            builder.HasData(new Core.Entities.Test.Test()
            {
                Key = "key1",
                Value = "value1",
                CreatedById = TableKeys.SYSTEM_USER_ID
            },
            new Core.Entities.Test.Test()
            {
                Key = "key2",
                Value = "value2",
                CreatedById = TableKeys.SYSTEM_USER_ID
            });
        }
    }
}
