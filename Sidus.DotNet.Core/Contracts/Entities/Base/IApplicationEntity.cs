using Sidus.DotNetFramework.Base.Entity.Interface;
using System;

namespace Sidus.DotNet.Core.Contracts.Entities.Base
{
    public interface IApplicationEntity : IEntity<Guid>
    {
        string StateAsText { get; }
        bool IsActive { get; }
        bool IsDeleted { get; }
    }
}
