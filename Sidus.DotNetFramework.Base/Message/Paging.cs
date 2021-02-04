using Sidus.DotNetFramework.Base.Message.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Message
{
    public class Paging : IPagingRequest
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }

    public class PagingResult : IPagingResponse
    {
        public int Index { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
    }
}
