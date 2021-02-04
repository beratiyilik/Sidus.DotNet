using Sidus.DotNetFramework.Base.Message.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Message
{
    public abstract class BaseFilter : IFilter
    {
        public Enums.Enums.EntityState? State { get; set; }
    }

    public abstract class BaseFilter<TKey> : BaseFilter, IFilter<TKey> where TKey : IEquatable<TKey>
    {
        public BaseFilter()
        {
            this.Keys = new TKey[] { };
        }

        public TKey Key { get; set; }
        public IEnumerable<TKey> Keys { get; set; }
    }

}
