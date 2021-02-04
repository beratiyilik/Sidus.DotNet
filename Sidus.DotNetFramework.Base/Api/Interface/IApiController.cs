using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Sidus.DotNetFramework.Base.Entity.Interface;
using Sidus.DotNetFramework.Base.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Api.Interface
{
    public interface IApiController<TEntity, TModel, TKey> where TEntity : IEntity<TKey> where TModel : IModel<TKey> where TKey : IEquatable<TKey>
    {
        IActionResult Get();
        IActionResult Get(TKey id);
        IActionResult Put(TKey id, TModel model);
        IActionResult Post(TModel model);
        // IActionResult Patch(TKey id, JsonPatchDocument<TModel> model);
        IActionResult Delete(TKey id);
    }
}
