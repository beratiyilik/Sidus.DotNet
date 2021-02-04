using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Model.Interface
{

    public interface IModel
    {
        object Id { get; set; }
    }

    public interface IModel<TKey> : IModel where TKey : IEquatable<TKey>
    {
        new TKey Id { get; set; }
    }
}
