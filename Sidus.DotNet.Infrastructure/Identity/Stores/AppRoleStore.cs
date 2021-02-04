using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sidus.DotNet.Core.Entities.Identity;
using Sidus.DotNet.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNet.Infrastructure.Identity.Stores
{
    public class AppRoleStore : RoleStore<Role, ApplicationDbContext, Guid, UserRole, RoleClaim>, IDisposable
    {
        /*
        public AppRoleStore() : this(new ApplicationDbContext(), null)
        {

        }
        */

        public AppRoleStore(ApplicationDbContext context) : this(context, null)
        {

        }

        public AppRoleStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {

        }
    }
}
