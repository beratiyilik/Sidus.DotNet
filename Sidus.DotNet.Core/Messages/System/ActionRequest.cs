using AutoMapper;
using Sidus.DotNet.Application.Messages.Base;
using Sidus.DotNet.Core.Models.System;

namespace Sidus.DotNet.Core.Messages.System
{
    public class ActionRequest : BaseApplicaitonRequest<Sidus.DotNet.Core.Entities.System.Action, ActionModel>
    {
        public ActionRequest(IMapper mapper) : base(mapper) { }
    }
}
