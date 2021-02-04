using Sidus.DotNet.Core.Contracts.Entities.Base;
using Sidus.DotNet.Core.Contracts.Models.Base;
using Sidus.DotNetFramework.Base.Service.Interface;
using System;

namespace Sidus.DotNet.Core.Contracts.Services.Base
{
    public interface IApplicationService<TEntity, TModel> : IService<TEntity, TModel, Guid> where TEntity : IApplicationEntity where TModel : IApplicationModel { }
}
