using AutoMapper;
using Sidus.DotNet.Application.Messages.Base;
using Sidus.DotNet.Core.Models.Test;

namespace Sidus.DotNet.Core.Messages.Test
{
    public class TestRequest : BaseApplicaitonRequest<Sidus.DotNet.Core.Entities.Test.Test, TestModel>
    {
        public TestRequest(IMapper mapper) : base(mapper) { }
    }
}
