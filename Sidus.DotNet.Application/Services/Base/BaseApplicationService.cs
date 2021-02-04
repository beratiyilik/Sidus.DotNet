using AutoMapper;
using Sidus.DotNet.Core.Contracts.Repositories.Base;
using Sidus.DotNet.Core.Contracts.Services.Base;
using Sidus.DotNet.Core.Entities.Base;
using Sidus.DotNet.Core.Models.Base;
using Sidus.DotNetFramework.Base.Service;
using System;
using System.Collections.Generic;

namespace Sidus.DotNet.Application.Services.Base
{
    public abstract class BaseApplicationService<TEntity, TModel> : BaseService<TEntity, TModel, Guid>, IApplicationService<TEntity, TModel> where TEntity : BaseApplicationEntity where TModel : BaseApplicationModel
    {
        private protected readonly IApplicationRepository<TEntity> _repository;
        private protected readonly IMapper _mapper;

        public BaseApplicationService(IApplicationRepository<TEntity> repository, IMapper mapper) : base(repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override TModel ToModel(TEntity entity) => this._mapper.Map<TModel>(entity);

        public override IEnumerable<TModel> ToModels(IEnumerable<TEntity> entities) => this._mapper.Map<IEnumerable<TModel>>(entities);

        public override TEntity ToEntity(TModel model) => this._mapper.Map<TEntity>(model);

        public override IEnumerable<TEntity> ToEntities(IEnumerable<TModel> models) => this._mapper.Map<IEnumerable<TEntity>>(models);
    }
}
