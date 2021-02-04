using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Entity.Interface
{
    public interface IEntity<TKey> : IAudited<TKey>, IHasState, IHasTimestamp where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
