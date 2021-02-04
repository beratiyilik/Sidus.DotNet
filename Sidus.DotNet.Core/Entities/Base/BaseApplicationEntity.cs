using Sidus.DotNet.Core.Contracts.Entities.Base;
using Sidus.DotNetFramework.Base.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Sidus.DotNetFramework.Base.Enums.Enums;

namespace Sidus.DotNet.Core.Entities.Base
{
    public abstract class BaseApplicationEntity : BaseEntity<Guid>, IApplicationEntity
    {
        public BaseApplicationEntity() : base()
        {
            this.Id = GuidGenerator.GenerateTimeBasedGuid();
            this.CreatedAt = DateTime.UtcNow;
            this.CreatedById = Guid.Empty; // TODO: set user id OnSave after implementation identity
            this.State = EntityState.Active;
        }

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
    }
}
