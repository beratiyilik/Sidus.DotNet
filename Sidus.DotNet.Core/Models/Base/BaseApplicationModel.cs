using Sidus.DotNet.Core.Contracts.Models.Base;
using Sidus.DotNetFramework.Base.Model;
using System;

namespace Sidus.DotNet.Core.Models.Base
{
    public abstract class BaseApplicationModel : BaseModel<Guid>, IApplicationModel
    {
    }
}
