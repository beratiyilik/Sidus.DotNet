using AutoMapper;
using Sidus.DotNet.Application.Messages.Base;
using Sidus.DotNet.Core.Messages.Base;
using Sidus.DotNet.Core.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNet.Core.Messages.Test
{
    public class TestResponse : BaseApplicationResponse<Sidus.DotNet.Core.Entities.Test.Test, TestModel>
    {
        public TestResponse(IMapper mapper) : base(mapper) { }
    }
}
