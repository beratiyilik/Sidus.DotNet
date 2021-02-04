using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNet.Core.Enums
{
    public static class Enums
    {
        [Description("Action Type")]
        public enum ActionType
        {
            [Description("None")]
            Null = 0,
            [Description("Area")]
            Area = 1,
            [Description("Controller")]
            Controller = 2,
            [Description("Action")]
            Action = 3
        }
    }
}
