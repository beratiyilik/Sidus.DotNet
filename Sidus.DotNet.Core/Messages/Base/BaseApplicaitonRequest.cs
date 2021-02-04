using Sidus.DotNet.Core.Entities.Base;
using Sidus.DotNetFramework.Base.Message;
using System;
using System.Collections.Generic;
using Sidus.DotNet.Core.Contracts.Messages.Base;
using Sidus.DotNet.Core.Models.Base;
using AutoMapper;
using Sidus.DotNet.Core.Contracts.Entities.Base;
using Sidus.DotNet.Core.Contracts.Models.Base;

namespace Sidus.DotNet.Application.Messages.Base
{
    public class BaseApplicaitonRequest : BaseRequest, IApplicationRequest
    {
        public BaseApplicaitonRequest() : base() { }
    }

    public class BaseApplicaitonRequest<TEntity, TModel> : BaseRequest<TEntity, TModel, Guid>, IApplicationRequest<TEntity, TModel> where TEntity : /* IApplicationEntity */ BaseApplicationEntity where TModel : /* IApplicationModel */ BaseApplicationModel
    {
        private protected readonly IMapper _mapper;

        public BaseApplicaitonRequest(IMapper mapper) : base()
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override TEntity ToEntity() => _mapper.Map<TEntity>(this.Model);

        public override IEnumerable<TEntity> ToEntities() => _mapper.Map<IEnumerable<TEntity>>(this.Models);
    }
}
