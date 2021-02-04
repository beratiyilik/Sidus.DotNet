using Sidus.DotNet.Core.Contracts.Entities.Base;
using Sidus.DotNet.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Sidus.DotNet.Core.Enums.Enums;

namespace Sidus.DotNet.Core.Entities.System
{
    [Table("Action", Schema = "System")]
    public class Action : BaseApplicationEntity, IApplicationEntity
    {
        public Action() : base()
        {

        }

        public Guid? ParentId { get; set; }
        public virtual Action Parent { get; set; }
        public ActionType Type { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string HttpMethods { get; set; }
        public string Parameters { get; set; }
        public string RouteTemplate { get; set; }
        public string ReturnTypeAndSignature { get; set; }
        public virtual ICollection<Core.Entities.System.Action> Childs { get; set; }
    }
}
