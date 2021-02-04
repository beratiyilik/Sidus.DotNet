using AutoMapper;
using Sidus.DotNet.Core.Contracts.Entities.Base;
using Sidus.DotNet.Core.Contracts.Messages.Base;
using Sidus.DotNet.Core.Contracts.Models.Base;
using Sidus.DotNet.Core.Entities.Base;
using Sidus.DotNet.Core.Models.Base;
using Sidus.DotNetFramework.Base.Message;
using System;
using System.Collections.Generic;

namespace Sidus.DotNet.Core.Messages.Base
{
    public class BaseApplicationResponse : BaseResponse, IApplicationResponse
    {
        public BaseApplicationResponse() : base() { }
    }

    public class BaseApplicationResponse<TModel> : BaseResponse<TModel>, IApplicationResponse<TModel> where TModel : /* IApplicationModel */ BaseApplicationModel
    {
        public BaseApplicationResponse() : base() { }
    }

    public class BaseApplicationResponse<TEntity, TModel> : BaseResponse<TEntity, TModel, Guid>, IApplicationResponse<TEntity, TModel> where TEntity : /* IApplicationEntity */ BaseApplicationEntity where TModel : /* IApplicationModel */ BaseApplicationModel
    {
        private protected readonly IMapper _mapper;

        public BaseApplicationResponse(IMapper mapper) : base()
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override void AddResult(TEntity entity) => this.AddResult(_mapper.Map<TModel>(entity));

        public override void AddResult(IEnumerable<TEntity> entities) => this.AddResult(_mapper.Map<IEnumerable<TModel>>(entities));
    }
}
