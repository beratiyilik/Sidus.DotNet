using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Constant
{
    public static class BaseApiActionKeys
    {
        /* Guid.NewGuid().ToString().Substring(24); */
        public const string GET = "6CBFDC08405F";
        public const string GET_WITH_ID = "50DCF77D5D0D";
        public const string PUT_WITH_ID_AND_MODEL = "5726BDE334B9";
        public const string POST_WITH_WITH_MODEL = "252BB98F46D8";
        public const string PATCH_WITH_ID_AND_JSON_PATCH_DOCUMENT_MODEL = "BB815432C524";
        public const string DELETE_WITH_ID = "74A89198E4C3";

        public static readonly IEnumerable<string> ALL = new string[] {
            GET,
            GET_WITH_ID,
            PUT_WITH_ID_AND_MODEL,
            POST_WITH_WITH_MODEL,
            PATCH_WITH_ID_AND_JSON_PATCH_DOCUMENT_MODEL,
            DELETE_WITH_ID
        };
    }
}
