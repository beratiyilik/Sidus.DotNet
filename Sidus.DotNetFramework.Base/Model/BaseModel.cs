using Sidus.DotNetFramework.Base.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Model
{
    public abstract class BaseModel : IModel
    {
        public object Id { get; set; }
    }

    public abstract class BaseModel<TKey> : BaseModel, IModel<TKey> where TKey : IEquatable<TKey>
    {
        public new TKey Id { get; set; }
    }
}
