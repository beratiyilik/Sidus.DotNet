using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidus.DotNet.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNet.Infrastructure.Identity.Managers
{
    public class AppSignInManager : SignInManager<User>
    {
        private AppUserManager _userManager;
        private AppUserClaimsPrincipalFactory _claimsFactory;
        public AppSignInManager(AppUserManager userManager, IHttpContextAccessor contextAccessor, AppUserClaimsPrincipalFactory claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<User>> logger, IAuthenticationSchemeProvider schemes) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _claimsFactory = claimsFactory ?? throw new ArgumentNullException(nameof(claimsFactory));
        }
    }
}
