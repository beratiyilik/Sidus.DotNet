using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Entity.Interface
{
    public interface IHasDomain<TKey> where TKey : IEquatable<TKey>
    {
        TKey DomainId { get; set; }
    }
}
