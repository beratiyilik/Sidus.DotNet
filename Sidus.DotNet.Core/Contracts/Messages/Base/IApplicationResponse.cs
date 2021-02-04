using Sidus.DotNet.Core.Contracts.Entities.Base;
using Sidus.DotNet.Core.Contracts.Models.Base;
using Sidus.DotNetFramework.Base.Message.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNet.Core.Contracts.Messages.Base
{
    public interface IApplicationResponse : IResponse { }

    public interface IApplicationResponse<TModel> : IApplicationResponse, IResponse<TModel> where TModel : IApplicationModel { }

    public interface IApplicationResponse<TEntity, TModel> : IApplicationResponse, IResponse<TEntity, TModel, Guid> where TEntity : IApplicationEntity where TModel : IApplicationModel { }
}
