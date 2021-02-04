using Sidus.DotNetFramework.Base.Message.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sidus.DotNetFramework.Base.Enums.Enums;

namespace Sidus.DotNetFramework.Base.Message
{
    public class ResponseMessage : IResponseMessage
    {
        public ResponseMessage(string message, OperationResult type)
        {
            this.Message = message;
            this.Type = type;
        }

        public string Message { get; set; }
        public OperationResult Type { get; set; }
    }
}
