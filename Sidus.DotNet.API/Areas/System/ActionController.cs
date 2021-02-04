using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Sidus.DotNet.API.Controllers.Base;
using Sidus.DotNet.Core.Messages.System;
using Sidus.DotNet.Core.Contracts.Services.Action;
using Sidus.DotNet.Core.Models.System;
using Sidus.DotNetFramework.Base.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using Sidus.DotNet.Core.Messages.Base;
using AutoMapper;

namespace Sidus.DotNet.API.Areas.System
{
    [RegisterController("FC6F46F0-94C3-4151-BB42-091816587F41")]
    [Route("api/[area]/[controller]/[action]")]
    [SystemArea]
    public class ActionController : ApplicationApiController<Core.Entities.System.Action, ActionModel>
    {
        private readonly IActionService _service;
        private readonly IActionDescriptorCollectionProvider _provider;
        private readonly IMapper _mapper;

        public ActionController(IActionService servive, IActionDescriptorCollectionProvider provider, IMapper mapper) : base(servive)
        {
            _service = servive ?? throw new ArgumentNullException(nameof(servive));
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [RegisterAction("25296E1D-AB5A-44B1-823F-6888215A839E")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override IActionResult Get()
        {
            var response = this._service.List(new ActionRequest(_mapper)
            {
                Filter = m => m.State == DotNetFramework.Base.Enums.Enums.EntityState.Active,
                Include = m => m.Include(n => n.Parent).Include(m => m.Childs),
                OrderBy = m => m.OrderBy(n => n.CreatedAt),
            });

            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public override IActionResult Put(Guid id, [FromBody] ActionModel model) => StatusCode(StatusCodes.Status501NotImplemented, "Not Implemented!");
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public override IActionResult Post([FromBody] ActionModel model) => StatusCode(StatusCodes.Status501NotImplemented, "Not Implemented!");
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public override IActionResult Patch(Guid id, [FromBody] JsonPatchDocument<ActionModel> model) => StatusCode(StatusCodes.Status501NotImplemented, "Not Implemented!");
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public override IActionResult Delete(Guid id) => StatusCode(StatusCodes.Status501NotImplemented, "Not Implemented!");

        [RegisterAction("D171F144-12BF-46D1-8BC2-56B489055DF5")]
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Update()
        {
            var response = new ActionResponse(_mapper);

            try
            {
                var request = new ActionRequest(_mapper)
                {
                    Models = GetActions()
                };

                response = (ActionResponse)_service.Update(request);
            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }

            return Ok(response);
        }

        [RegisterAction("F8E7F650-479D-41E7-A7CD-9F2BD9B628EB")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Actions()
        {
            var response = new BaseApplicationResponse<ActionModel>();

            response.AddResult(GetActions());

            return Ok(response);
        }

        private IEnumerable<ActionModel> GetActions()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().Where(m => m.FullName.Contains("Sidus.DotNet.API")).FirstOrDefault();

            var types = assembly.GetTypes();

            var controllersHasArea = (from controller in types.Where(m => m.GetCustomAttributes<BaseAreaAttribute>(true).Any())
                                      select new
                                      {
                                          Controller = controller,
                                          AreaAttribute = controller.GetCustomAttribute<BaseAreaAttribute>(true),
                                          RegisterAttribute = controller.GetCustomAttribute<BaseRegisterAttribute>(true)
                                      });

            var registeredControllers = (from controller in types.Where(m => m.GetCustomAttributes<BaseRegisterAttribute>(true).Any())
                                         select new
                                         {
                                             Controller = controller,
                                             AreaAttribute = controller.GetCustomAttribute<BaseAreaAttribute>(true),
                                             RegisterAttribute = controller.GetCustomAttribute<BaseRegisterAttribute>(true)
                                         });

            var methods = types.SelectMany(m => m.GetMethods());

            var registeredActions = (from action in methods.Where(m => m.GetCustomAttributes<BaseRegisterAttribute>().Any())
                                     select new
                                     {
                                         Action = action,
                                         RegisterAttribute = action.GetCustomAttribute<BaseRegisterAttribute>(true)
                                     });

            var nonOverrideBaseApiActions = (from controller in types.Where(m => m.GetCustomAttributes<BaseRegisterAttribute>(true).Any())
                                             from action in controller.GetMethods()
                                             where action.IsPublic
                                             && action.IsVirtual
                                             && action.DeclaringType.Name.Contains("BaseApiController")
                                             && !action.DeclaringType.Name.Contains("ControllerBase")
                                             && action.GetCustomAttributes<RegisterBaseApiActionAttribute>(true).Any()
                                             select new
                                             {
                                                 Controller = controller,
                                                 ControllerId = controller.GetCustomAttribute<RegisterControllerAttribute>(true).Id,
                                                 Action = action,
                                                 Suffix = action.GetCustomAttribute<RegisterBaseApiActionAttribute>(true).Suffix,
                                                 ActionId = Guid.Parse($"{controller.GetCustomAttribute<RegisterControllerAttribute>(true).Id.ToString().Substring(0, 24)}{action.GetCustomAttribute<RegisterBaseApiActionAttribute>(true).Suffix}")
                                             });

            var list = new List<ActionModel>();

            // adding areas
            list.AddRange(controllersHasArea.Select(m => new ActionModel()
            {
                Id = m.AreaAttribute.Id, // AreaId
                Name = m.AreaAttribute.TypeId.GetType().GetProperty("Name").GetValue(m.AreaAttribute.TypeId, null).ToString(),
                FullName = m.AreaAttribute.TypeId.GetType().GetProperty("FullName").GetValue(m.AreaAttribute.TypeId, null).ToString(),
                Type = Core.Enums.Enums.ActionType.Area
            }).Distinct().ToList());

            // adding registered controllers
            list.AddRange(registeredControllers.Select(m => new ActionModel()
            {
                Id = m.RegisterAttribute.Id, // ControllerId
                Name = m.Controller.Name,
                FullName = m.Controller.FullName,
                Type = Core.Enums.Enums.ActionType.Controller,
                ParentId = m.AreaAttribute?.Id, // AreaId
            }).ToList());

            // adding registered actions
            list.AddRange(registeredActions.Select(m => new ActionModel()
            {
                Id = m.RegisterAttribute.Id, // ActionId
                Name = m.Action.Name,
                FullName = $"{m.Action.DeclaringType.FullName}.{m.Action.Name}",
                Type = Core.Enums.Enums.ActionType.Action,
                ReturnTypeAndSignature = m.Action.ToString(),
                ParentId = m.Action.DeclaringType.GetCustomAttributes<BaseRegisterAttribute>(true).FirstOrDefault()?.Id, // ControllerId
            }).ToList());

            // adding non overriede base api actions
            list.AddRange(nonOverrideBaseApiActions.Select(m => new ActionModel
            {
                Id = m.ActionId,
                Name = m.Action.Name,
                FullName = $"{m.Controller.FullName}.{m.Action.Name}",
                Type = Core.Enums.Enums.ActionType.Action,
                ParentId = m.ControllerId, // ControllerId
                ReturnTypeAndSignature = m.Action.ToString()
            }));

            // TODO: refactor
            var allRoutes = _provider
                    .ActionDescriptors
                    .Items
                    .OfType<ControllerActionDescriptor>()
                    .Where(m => !m.ControllerName.IsNullOrEmpty())
                    .Select(m => new
                    {
                        FullName = m.DisplayName,
                        ControllerName = m.ControllerName,
                        Name = m.ActionName,
                        AttributeRouteTemplate = m.AttributeRouteInfo?.Template,
                        HttpMethods = string.Join(", ", m.ActionConstraints?.OfType<HttpMethodActionConstraint>().SingleOrDefault()?.HttpMethods ?? null),
                        Parameters = m.Parameters.Any() ? string.Join(", ", m.Parameters.Select(k => $"{k.ParameterType.FullName} {k.Name}").ToArray()) : null,
                        ControllerFullName = m.ControllerTypeInfo.FullName,
                        AreaId = m.ControllerTypeInfo.GetCustomAttribute<BaseAreaAttribute>(true)?.Id,
                        ControllerId = m.ControllerTypeInfo.GetCustomAttribute<BaseRegisterAttribute>(true).Id,
                        ActionId = m.MethodInfo.GetCustomAttribute<BaseRegisterAttribute>(true)?.Id
                        ?? Guid.Parse($"{m.ControllerTypeInfo.GetCustomAttribute<BaseRegisterAttribute>(true).Id.ToString().Substring(0, 24)}{m.MethodInfo.GetCustomAttribute<RegisterBaseApiActionAttribute>(true).Suffix}"),
                        ActionMethodName = m.MethodInfo.Name,
                        Filters = m.FilterDescriptors?.Select(f => new
                        {
                            ClassName = f.Filter.GetType().FullName,
                            f.Scope /* 10 = Global, 20 = Controller, 30 = Action */
                        }),
                        Constraints = m.ActionConstraints?.Select(c => new
                        {
                            Type = c.GetType().Name
                        }),
                        RouteValues = m.RouteValues.Select(r => new
                        {
                            r.Key,
                            r.Value
                        }),
                        Type = Core.Enums.Enums.ActionType.Action
                    }).AsEnumerable();


            foreach (var item in list)
            {
                var route = allRoutes.FirstOrDefault(m => m.ActionId == item.Id);
                if (route != null)
                {
                    item.HttpMethods = route.HttpMethods;
                    item.Parameters = route.Parameters;
                    item.RouteTemplate = route.AttributeRouteTemplate;
                }
            }

            return list;
        }
    }
}
