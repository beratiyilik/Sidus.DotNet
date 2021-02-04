using Sidus.DotNet.Core.Messages.System;
using Sidus.DotNet.Application.Services.Base;
using Sidus.DotNet.Core.Contracts.Repositories.System;
using Sidus.DotNet.Core.Contracts.Services.Action;
using Sidus.DotNet.Core.Models.System;
using Sidus.DotNetFramework.Base.Message.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;
using Action = Sidus.DotNet.Core.Entities.System.Action;
using AutoMapper;

namespace Sidus.DotNet.Application.Services.System
{
    public class ActionService : BaseApplicationService<Action, ActionModel>, IActionService
    {
        public ActionService(IActionRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override Task<IResponse<Action, ActionModel, Guid>> InsertAsync(IRequest<Action, ActionModel, Guid> request) => throw new NotImplementedException();

        public override Task<IResponse<Action, ActionModel, Guid>> UpdateAsync(IRequest<Action, ActionModel, Guid> request)
        {
            var response = new ActionResponse(_mapper);
            try
            {
                // TODO: transaction

                var entityList = ((ActionRequest)request).ToEntities();

                var currentEntityList = this._repository.ListAsync(m => m.State == DotNetFramework.Base.Enums.Enums.EntityState.Active).GetAwaiter().GetResult().ToList();

                var insertIds = entityList.Select(m => m.Id).Except(currentEntityList.Select(m => m.Id));
                if (insertIds.Any())
                {
                    var result = this._repository.InsertAsync(entityList.Where(m => insertIds.Contains(m.Id))).GetAwaiter().GetResult();
                    response.AddResult(result);
                }

                var updateIds = entityList.Select(m => m.Id).Intersect(currentEntityList.Select(m => m.Id));
                if (updateIds.Any())
                {
                    var updateEntityList = currentEntityList.Where(m => updateIds.Contains(m.Id)).ToList();

                    foreach (var updateEntity in updateEntityList)
                    {
                        var entity = entityList.FirstOrDefault(m => m.Id == updateEntity.Id);

                        /*
                        var index = updateEntityList.IndexOf(updateEntity);
                        if (index != -1 && entity != null)
                            updateEntityList[index] = entityList.FirstOrDefault(m => m.Id == updateEntity.Id);
                        */

                        if (entity != null)
                        {
                            updateEntity.ParentId = entity.ParentId;
                            updateEntity.Type = entity.Type;
                            updateEntity.Name = entity.Name;
                            updateEntity.FullName = entity.FullName;
                            updateEntity.HttpMethods = entity.HttpMethods;
                            updateEntity.Parameters = entity.Parameters;
                            updateEntity.RouteTemplate = entity.RouteTemplate;
                            updateEntity.ReturnTypeAndSignature = entity.ReturnTypeAndSignature;
                        }
                    }

                    var result = this._repository.UpdateAsync(updateEntityList).GetAwaiter().GetResult();
                    response.AddResult(result);
                }

                var deleteIds = currentEntityList.Select(m => m.Id).Except(entityList.Select(m => m.Id));
                if (deleteIds.Any())
                {
                    var result = this._repository.DeleteAsync(deleteIds);
                }

            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }
            return Task.FromResult<IResponse<Core.Entities.System.Action, ActionModel, Guid>>(response);
        }

        public override Task<IResponse<Action, ActionModel, Guid>> DeleteAsync(IRequest<Action, ActionModel, Guid> request) => throw new NotImplementedException();
    }
}
