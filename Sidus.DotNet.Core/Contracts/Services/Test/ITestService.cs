using Sidus.DotNet.Core.Contracts.Services.Base;
using Sidus.DotNet.Core.Models.Test;

namespace Sidus.DotNet.Core.Contracts.Services.Test
{
    public interface ITestService : IApplicationService<Sidus.DotNet.Core.Entities.Test.Test, TestModel>
    {

    }
}
