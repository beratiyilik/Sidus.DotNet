using Sidus.DotNet.Core.Contracts.Repositories.System;
using Sidus.DotNet.Infrastructure.Data;
using Sidus.DotNet.Infrastructure.Repositories.Base;

namespace Sidus.DotNet.Infrastructure.Repositories.System
{
    public class ActionRepository : BaseApplicationRepository<Sidus.DotNet.Core.Entities.System.Action>, IActionRepository
    {
        public ActionRepository(ApplicationDbContext context) : base(context) { }
    }
}
