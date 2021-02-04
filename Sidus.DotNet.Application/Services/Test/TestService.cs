using AutoMapper;
using Sidus.DotNet.Application.Services.Base;
using Sidus.DotNet.Core.Contracts.Repositories.Test;
using Sidus.DotNet.Core.Contracts.Services.Test;
using Sidus.DotNet.Core.Models.Test;
using System;

namespace Sidus.DotNet.Application.Services.Test
{
    public class TestService : BaseApplicationService<Sidus.DotNet.Core.Entities.Test.Test, TestModel>, ITestService
    {
        public TestService(ITestRepository testRepository, IMapper mapper) : base(testRepository, mapper) { }
    }
}
