using Sidus.DotNet.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Sidus.DotNet.Infrastructure.Identity.Stores;

namespace Sidus.DotNet.Infrastructure.Identity.Managers
{
    public class AppUserManager : UserManager<User> /* IApplicationUserManager */
    {
        private AppUserStore _store;
        public AppUserManager(AppUserStore store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _store = store ?? throw new ArgumentNullException(nameof(store));
        }
    }
}
