using Sidus.DotNet.Core.Entities.Base;
using Sidus.DotNet.Infrastructure.Data;
using System;
using Sidus.DotNetFramework.Base.Repository;
using Sidus.DotNet.Core.Contracts.Repositories.Base;

namespace Sidus.DotNet.Infrastructure.Repositories.Base
{
    public abstract class BaseApplicationRepository<TEntity> : BaseRepository<TEntity, Guid, ApplicationDbContext>, IApplicationRepository<TEntity> where TEntity : BaseApplicationEntity
    {
        public BaseApplicationRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
