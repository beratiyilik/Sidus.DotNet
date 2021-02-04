using System;
using Sidus.DotNetFramework.Base.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Sidus.DotNet.Core.Contracts.Entities.Base;

namespace Sidus.DotNet.Core.Contracts.Repositories.Base
{
    public interface IApplicationRepository<TEntity> : IRepository<TEntity, Guid, DbContext> where TEntity : IApplicationEntity
    {

    }
}
