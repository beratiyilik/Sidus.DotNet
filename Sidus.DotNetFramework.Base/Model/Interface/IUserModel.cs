using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Sidus.DotNetFramework.Base.Enums.Enums;

namespace Sidus.DotNetFramework.Base.Model.Interface
{
    public interface IUserModel : IModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        string FullName { get; }
        string Email { get; set; }
        string Password { get; set; }
        EntityState State { get; set; }
        EntityType EntityType { get; set; }
    }

    public interface IUserModel<TKey> : IUserModel, IModel<TKey> where TKey : IEquatable<TKey>
    {

    }

    public interface ICurrentUserModel : IUserModel, IPrincipal
    {
        IEnumerable<string> Roles { get; }
        IUserModel UserData { get; }
    }

    public interface ICurrentUserModel<TKey> : ICurrentUserModel, IUserModel<TKey> where TKey : IEquatable<TKey>
    {
        new TKey Id { get; }
        new IUserModel<TKey> UserData { get; }
    }
}
