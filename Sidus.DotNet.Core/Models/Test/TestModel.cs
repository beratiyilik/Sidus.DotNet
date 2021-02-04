using Sidus.DotNet.Core.Contracts.Models.Base;
using Sidus.DotNet.Core.Models.Base;

namespace Sidus.DotNet.Core.Models.Test
{
    public class TestModel : BaseApplicationModel, IApplicationModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
