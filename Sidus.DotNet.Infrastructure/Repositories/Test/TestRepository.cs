using Sidus.DotNet.Core.Contracts.Repositories.Test;
using Sidus.DotNet.Infrastructure.Data;
using Sidus.DotNet.Infrastructure.Repositories.Base;

namespace Sidus.DotNet.Infrastructure.Repositories.Test
{
    public class TestRepository : BaseApplicationRepository<Sidus.DotNet.Core.Entities.Test.Test>, ITestRepository
    {
        public TestRepository(ApplicationDbContext context) : base(context) { }

    }
}
