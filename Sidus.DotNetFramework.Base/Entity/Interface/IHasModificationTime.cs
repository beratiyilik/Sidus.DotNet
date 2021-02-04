using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Entity.Interface
{
    public interface IHasModificationTime
    {
        Nullable<DateTime> LastModifiedAt { get; set; }
    }
}
