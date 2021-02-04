using Sidus.DotNet.Core.Contracts.Entities.Base;
using Sidus.DotNet.Core.Contracts.Models.Base;
using Sidus.DotNetFramework.Base.Message.Interface;
using System;

namespace Sidus.DotNet.Core.Contracts.Messages.Base
{
    public interface IApplicationRequest : IRequest { }

    public interface IApplicationRequest<TEntity, TModel> : IApplicationRequest, IRequest<TEntity, TModel, Guid> where TEntity : IApplicationEntity where TModel : IApplicationModel { }
}
