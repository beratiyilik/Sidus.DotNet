using Microsoft.AspNetCore.Identity;
using Sidus.DotNet.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNet.Infrastructure.Identity.Validators
{
    public class AppUserValidator : UserValidator<User>
    {
        public AppUserValidator(IdentityErrorDescriber errors) : base(errors)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            IdentityResult result = await base.ValidateAsync(manager, user);
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();
            if (user.UserName.ToLower().Contains("admin"))
            {
                errors.Add(new IdentityError
                {
                    Code = "InvalidUser",
                    Description = ""
                });
            }
            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());

        }
    }
}
