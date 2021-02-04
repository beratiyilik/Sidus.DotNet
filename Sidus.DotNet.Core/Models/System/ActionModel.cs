using Sidus.DotNet.Core.Contracts.Models.Base;
using Sidus.DotNet.Core.Models.Base;
using System;
using System.Collections.Generic;
using static Sidus.DotNet.Core.Enums.Enums;

namespace Sidus.DotNet.Core.Models.System
{
    public class ActionModel : BaseApplicationModel, IApplicationModel
    {
        public ActionModel()
        {
            this.Childs = new List<ActionModel>();
        }
        public Guid? ParentId { get; set; }
        public ActionModel Parent { get; set; }
        public ActionType Type { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string HttpMethods { get; set; }
        public string Parameters { get; set; }
        public string RouteTemplate { get; set; }
        public string ReturnTypeAndSignature { get; set; }
        public IEnumerable<ActionModel> Childs { get; set; }
    }
}
