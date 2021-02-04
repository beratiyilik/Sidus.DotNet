using MediatR;
using Microsoft.EntityFrameworkCore;
using Sidus.DotNet.Core.Entities;
using Sidus.DotNet.Core.Entities.Base;
using System;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sidus.DotNet.Core.Entities.Identity;
using Sidus.DotNet.Infrastructure.Configuration.Identity;
using Sidus.DotNet.Core.Entities.Test;
using Sidus.DotNet.Infrastructure.Configuration.Test;
using Sidus.DotNet.Core.Entities.System;
using System.Reflection;

namespace Sidus.DotNet.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        private readonly IMediator _mediator;

        /*
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        */

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        /*
        public ApplicationDbContext() : base(ConfigurationManager.ConnectionStrings["PaymentSystem"].ConnectionString)
        {

        }

        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new PaymentSystemInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        */

        #region System

        /*
        public virtual IDbSet<ApplicationUserClaim> UserClaims { get; set; }
        public virtual IDbSet<ApplicationUserToken> UserTokens { get; set; }
        public virtual IDbSet<ApplicationUserLogin> UserLogins { get; set; }
        public virtual IDbSet<ApplicationRoleClaim> RoleClaims { get; set; }
        public virtual IDbSet<ApplicationUserRole> UserRoles { get; set; }
        */
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<Core.Entities.System.Action> Actions { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_mediator == null) return result;

            // dispatch events only if save was successful
            /*
            var entitiesWithEvents = ChangeTracker.Entries<BaseApplicationEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }
            */

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

    }
}
