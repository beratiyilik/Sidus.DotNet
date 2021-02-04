using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Entity.Interface
{
    public interface ICreationAudited<TKey> : IHasCreationTime where TKey : IEquatable<TKey>
    {
        TKey CreatedById { get; set; }
    }
}
