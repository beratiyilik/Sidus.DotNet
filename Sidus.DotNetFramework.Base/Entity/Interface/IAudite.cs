using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Entity.Interface
{
    public interface IAudited<TKey> : ICreationAudited<TKey>, IModificationAudited<TKey> where TKey : IEquatable<TKey>
    {
    }
}
