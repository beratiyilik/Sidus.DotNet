using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sidus.DotNet.Core.Entities.Identity;
using Sidus.DotNet.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNet.Infrastructure.Identity.Stores
{
    public class AppUserStore : UserStore<User, Role, ApplicationDbContext, Guid, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>, IDisposable
    {
        /*
        public AppUserStore() : this(new ApplicationDbContext(), null)
        {

        }
        */

        public AppUserStore(ApplicationDbContext context) : this(context, null)
        {

        }

        public AppUserStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {

        }
    }
}
