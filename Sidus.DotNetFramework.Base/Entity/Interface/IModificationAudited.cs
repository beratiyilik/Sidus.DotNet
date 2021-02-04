using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Entity.Interface
{
    public interface IModificationAudited<TKey> : IHasModificationTime where TKey : IEquatable<TKey>
    {
        // Nullable<TKey> LastModifiedById { get; set; }
        TKey LastModifiedById { get; set; }
    }
}
