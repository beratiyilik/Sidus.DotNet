using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sidus.DotNetFramework.Base.Enums.Enums;

namespace Sidus.DotNetFramework.Base.Message.Interface
{
    public interface IResponseMessage
    {
        string Message { get; set; }
        OperationResult Type { get; set; }
    }
}
