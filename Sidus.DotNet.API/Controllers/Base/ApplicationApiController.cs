using Sidus.DotNet.Core.Contracts.Controllers.Base;
using Sidus.DotNet.Core.Contracts.Services.Base;
using Sidus.DotNet.Core.Entities.Base;
using Sidus.DotNet.Core.Models.Base;
using Sidus.DotNetFramework.Base.Api;
using System;

namespace Sidus.DotNet.API.Controllers.Base
{
    public abstract class ApplicationApiController<TEntity, TModel> : BaseApiController<TEntity, TModel, Guid>, IApplicationApiController<TEntity, TModel> where TEntity : BaseApplicationEntity where TModel : BaseApplicationModel
    {
        public ApplicationApiController(IApplicationService<TEntity, TModel> service) : base(service)
        {

        }
    }
}
