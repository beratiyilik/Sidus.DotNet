using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sidus.DotNet.Core.Entities.Identity;
using Sidus.DotNet.Infrastructure.Identity.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNet.Infrastructure.Identity
{
    public class AppUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
    {
        private AppUserManager _userManager;
        private AppRoleManager _roleManager;
        private IOptions<IdentityOptions> _options;
        public AppUserClaimsPrincipalFactory(AppUserManager userManager, AppRoleManager roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);

            if (!claimsIdentity.HasClaim(m => m.Type == ClaimTypes.Sid && m.Value == Convert.ToString(user.Id)))
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Sid, Convert.ToString(user.Id), ClaimValueTypes.String));

            if (!claimsIdentity.HasClaim(m => m.Type == ClaimTypes.Name && m.Value == user.UserName))
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

            if (!claimsIdentity.HasClaim(m => m.Type == ClaimTypes.GivenName && m.Value == user.FirstName))
                claimsIdentity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName));

            if (!claimsIdentity.HasClaim(m => m.Type == ClaimTypes.Surname && m.Value == user.LastName))
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));

            if (!claimsIdentity.HasClaim(m => m.Type == ClaimTypes.Email && m.Value == user.Email))
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            // TODO: roles

            var roles = _userManager.GetRolesAsync(user).GetAwaiter().GetResult();

            var userDataAsString = JsonConvert.SerializeObject(new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.NationalIdentificationNumber,
                user.TaxNumber,
                user.EntityType,
                user.Email,
                user.UserName,
                user.CreatedAt,
                user.CreatedById,
                user.State,
                Roles = roles.Select(m => m).ToArray()
            });

            if (!claimsIdentity.HasClaim(m => m.Type == ClaimTypes.UserData && m.Value == userDataAsString))
                claimsIdentity.AddClaim(new Claim(ClaimTypes.UserData, userDataAsString));

            return claimsIdentity;
        }

    }
}
