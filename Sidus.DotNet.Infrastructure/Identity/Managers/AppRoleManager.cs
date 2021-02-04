using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Sidus.DotNet.Core.Entities.Identity;
using Sidus.DotNet.Infrastructure.Identity.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNet.Infrastructure.Identity.Managers
{
    public class AppRoleManager : RoleManager<Role>
    {
        private AppRoleStore _store;
        public AppRoleManager(AppRoleStore store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<Role>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
            _store = store ?? throw new ArgumentNullException(nameof(store));
        }
    }
}
