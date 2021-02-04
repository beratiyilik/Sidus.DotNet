using Microsoft.AspNetCore.Identity;
using Sidus.DotNet.Core.Contracts.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Sidus.DotNetFramework.Base.Enums.Enums;

namespace Sidus.DotNet.Core.Entities.Identity
{
    [Table("User", Schema = "Identity")]
    public class User : IdentityUser<Guid>, IApplicationEntity
    {
        public User() : base()
        {
            this.Id = GuidGenerator.GenerateTimeBasedGuid();
        }

        public User(string userName) : base(userName)
        {
            this.Id = GuidGenerator.GenerateTimeBasedGuid();
        }

        [Key]
        public new Guid Id { get; set; }

        public Guid CreatedById { get; set; }

        private Nullable<DateTime> _createdAt = null;
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get => _createdAt ?? DateTime.UtcNow; set => _createdAt = value; }

        // public Nullable<Guid> LastModifiedById { get; set; }
        public Guid LastModifiedById { get; set; }

        [DataType(DataType.DateTime)]
        public Nullable<DateTime> LastModifiedAt { get; set; }

        private Nullable<EntityState> _state = null;
        public EntityState State { get => _state ?? EntityState.Active; set => _state = value; }

        [Timestamp]
        public byte[] Version { get; set; }

        [NotMapped]
        public string StateAsText
        {
            get
            {
                var value = 0 + this.State;
                var v = value switch
                {
                    EntityState.Active => "Active",
                    EntityState.Passive => "Passive",
                    EntityState.Deleted => "Deleted",
                    EntityState.Null => "Null",
                    _ => "Unknown",
                };
                return v;
            }
        }

        [NotMapped]
        public bool IsActive => this.State == EntityState.Active;

        [NotMapped]
        public bool IsDeleted => this.State == EntityState.Deleted;

        public EntityType EntityType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalIdentificationNumber { get; set; }

        public string TaxNumber { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }

        public virtual ICollection<UserClaim> Claims { get; set; }

        public virtual ICollection<UserToken> Tokens { get; set; }

        /*
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(AppUserManager manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(AppUserManager manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
        */
    }
}
