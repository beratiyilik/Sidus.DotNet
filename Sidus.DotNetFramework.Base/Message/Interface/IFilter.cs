using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sidus.DotNetFramework.Base.Enums.Enums;

namespace Sidus.DotNetFramework.Base.Message.Interface
{
    public interface IFilter
    {
        EntityState? State { get; set; }
    }

    public interface IFilter<TKey> where TKey : IEquatable<TKey>
    {
        TKey Key { get; set; }
        IEnumerable<TKey> Keys { get; set; }
    }
}
