using Microsoft.AspNetCore.Identity;
using Sidus.DotNet.Core.Contracts.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sidus.DotNetFramework.Base.Enums.Enums;

namespace Sidus.DotNet.Core.Entities.Identity
{
    [Table("Role", Schema = "Identity")]
    public class Role : IdentityRole<Guid>, IApplicationEntity
    {
        public Role() : base()
        {
            this.Id = GuidGenerator.GenerateTimeBasedGuid();
        }

        public Role(string roleName) : base(roleName)
        {
            this.Id = GuidGenerator.GenerateTimeBasedGuid();
            this.Name = roleName;
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

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
