using Sidus.DotNet.Core.Contracts.Entities.Base;
using Sidus.DotNet.Core.Contracts.Models.Base;
using Sidus.DotNetFramework.Base.Api.Interface;
using System;

namespace Sidus.DotNet.Core.Contracts.Controllers.Base
{
    public interface IApplicationApiController<TEntity, TModel> : IApiController<TEntity, TModel, Guid> where TEntity : IApplicationEntity where TModel : IApplicationModel
    {

    }
}
