using AutoMapper;
using Sidus.DotNet.Application.Messages.Base;
using Sidus.DotNet.Core.Messages.Base;
using Sidus.DotNet.Core.Models.System;
using System;

namespace Sidus.DotNet.Core.Messages.System
{
    public class ActionResponse : BaseApplicationResponse<Sidus.DotNet.Core.Entities.System.Action, ActionModel>
    {
        public ActionResponse(IMapper mapper) : base(mapper) { }
    }
}
