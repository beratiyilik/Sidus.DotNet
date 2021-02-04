using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sidus.DotNetFramework.Base.Api.Interface;
using Sidus.DotNetFramework.Base.Entity;
using Sidus.DotNetFramework.Base.Message;
using Sidus.DotNetFramework.Base.Model.Interface;
using Sidus.DotNetFramework.Base.Model;
using Sidus.DotNetFramework.Base.Service.Interface;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Security.Claims;
using System;
using Sidus.DotNetFramework.Base.Attributes;
using Sidus.DotNetFramework.Base.Constant;

namespace Sidus.DotNetFramework.Base.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseApiController<TEntity, TModel, TKey> : ControllerBase, IApiController<TEntity, TModel, TKey> where TEntity : BaseEntity<TKey> where TModel : BaseModel<TKey> where TKey : IEquatable<TKey>
    {
        private protected readonly IService<TEntity, TModel, TKey> _service;

        public BaseApiController(IService<TEntity, TModel, TKey> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        private IHttpClientFactory _httpClientFactory;

        protected IHttpClientFactory HttpClientFactory => _httpClientFactory = HttpContext.RequestServices.GetService<IHttpClientFactory>();

        protected ICurrentUserModel<TKey> CurrentUser => new CurrentUserModel<TKey>(this.User as ClaimsPrincipal);

        [RegisterBaseApiAction(BaseApiActionKeys.GET)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual IActionResult Get()
        {
            var response = this._service.List(new BaseRequest<TEntity, TModel, TKey>()
            {
                Filter = m => m.State == Enums.Enums.EntityState.Active,
                OrderBy = m => m.OrderBy(n => n.CreatedAt),
            });

            return Ok(response);
        }

        [RegisterBaseApiAction(BaseApiActionKeys.GET_WITH_ID)]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual IActionResult Get(TKey id)
        {
            var response = this._service.GetByPrimaryKey(id);

            if (response.Result == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [RegisterBaseApiAction(BaseApiActionKeys.PUT_WITH_ID_AND_MODEL)]
        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual IActionResult Put(TKey id, [FromBody] TModel model)
        {
            if (!model.Id.Equals(id))
            {
                return BadRequest();
            }

            try
            {

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [RegisterBaseApiAction(BaseApiActionKeys.POST_WITH_WITH_MODEL)]
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public virtual IActionResult Post([FromBody] TModel model)
        {
            var response = this._service.Insert(new BaseRequest<TEntity, TModel, TKey>()
            {
                Model = model
            });

            return CreatedAtAction("Post", new { id = response.Result.Id }, response.Result);
        }

        [RegisterBaseApiAction(BaseApiActionKeys.PATCH_WITH_ID_AND_JSON_PATCH_DOCUMENT_MODEL)]
        [HttpPatch("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual IActionResult Patch(TKey id, [FromBody] JsonPatchDocument<TModel> model)
        {
            return new NoContentResult();
        }

        [RegisterBaseApiAction(BaseApiActionKeys.DELETE_WITH_ID)]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual IActionResult Delete(TKey id)
        {
            if (!IsExist(id))
            {
                return NotFound();
            }

            var response = this._service.Delete(new BaseRequest<TEntity, TModel, TKey>()
            {
                Key = id
            });

            return NoContent();
            // return Ok(response);
        }

        /*
        [HttpOptions]
        public virtual IActionResult Options() => new NoContentResult();
        */

        private bool IsExist(TKey key) => this._service.GetByPrimaryKey(key).AnyResult;
    }
}
