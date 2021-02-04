using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Message.Interface
{
    public interface IPagingRequest
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }

    public interface IPagingResponse
    {
        public int Count { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
    }
}
