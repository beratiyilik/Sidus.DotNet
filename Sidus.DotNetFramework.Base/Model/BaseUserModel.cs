using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Sidus.DotNetFramework.Base.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Sidus.DotNetFramework.Base.Enums.Enums;
using EntityState = Sidus.DotNetFramework.Base.Enums.Enums.EntityState;

namespace Sidus.DotNetFramework.Base.Model
{
    public abstract class BaseUserModel : BaseModel, IUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string FullName { get => $"{FirstName} {LastName}"; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EntityState State { get; set; }
        public EntityType EntityType { get; set; }
    }

    public abstract class BaseUserModel<TKey> : BaseUserModel, IUserModel<TKey> where TKey : IEquatable<TKey>
    {
        public new TKey Id { get; set; }
    }

    public class CurrentUserModel : /* BaseUserModel */ ClaimsPrincipal, ICurrentUserModel
    {
        public CurrentUserModel(ClaimsPrincipal principal) : base(principal)
        {

        }

        public object Id { get => this.FindFirst(ClaimTypes.Sid).Value; set { /* */ } }
        public string UserName { get => this.FindFirst(ClaimTypes.Name).Value; set { /* */ } }
        public string FirstName { get => this.FindFirst(ClaimTypes.GivenName).Value; set { /* */ } }
        public string LastName { get => this.FindFirst(ClaimTypes.Surname).Value; set { /* */ } }
        [JsonIgnore]
        public string FullName { get => $"{FirstName} {LastName}"; }
        public string Email { get => this.FindFirst(ClaimTypes.Email).Value; set { /* */ } }
        public IEnumerable<string> Roles { get => this.FindAll(ClaimTypes.Role).Select(m => m.Value); }
        public IUserModel UserData => JsonConvert.DeserializeObject<BaseUserModel>(this.FindFirst(ClaimTypes.UserData).Value);

        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public EntityState State { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public EntityType EntityType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class CurrentUserModel<TKey> : /* ClaimsPrincipal */ CurrentUserModel, ICurrentUserModel<TKey> where TKey : IEquatable<TKey>
    {
        public CurrentUserModel(ClaimsPrincipal principal) : base(principal)
        {

        }

        public new TKey Id { get => (TKey)Convert.ChangeType(this.FindFirst(ClaimTypes.Sid).Value, typeof(TKey)); set { /* */ } }

        public new IUserModel<TKey> UserData => JsonConvert.DeserializeObject<BaseUserModel<TKey>>(this.FindFirst(ClaimTypes.UserData).Value);
    }
}
