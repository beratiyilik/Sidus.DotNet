using Sidus.DotNetFramework.Base.Entity;
using Sidus.DotNetFramework.Base.Entity.Interface;
using Sidus.DotNetFramework.Base.Message.Interface;
using Sidus.DotNetFramework.Base.Model;
using Sidus.DotNetFramework.Base.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using static Sidus.DotNetFramework.Base.Enums.Enums;

namespace Sidus.DotNetFramework.Base.Message
{
    public class BaseResponse : IResponse
    {
        public BaseResponse()
        {
            this._messages = new List<IResponseMessage>();
        }

        [JsonIgnore]
        private IList<IResponseMessage> _messages = null;

        public IEnumerable<IResponseMessage> Messages => this._messages;

        public bool HasError => this._messages.Any(m => m.Type == OperationResult.Error);

        public void AddMessage(string message, OperationResult type) => this._messages = this._messages.Concat(new ResponseMessage[] { new ResponseMessage(message, type) }).ToList();

        public void AddWarning(string message) => this.AddMessage(message, OperationResult.Warning);

        public void AddWarning(string message, params object[] args) => this.AddWarning(String.Format(message, args));

        public void AddError(string error) => this.AddMessage(error, OperationResult.Error);

        public void AddError(IEnumerable<string> errors)
        {
            foreach (var message in errors)
            {
                this.AddError(message);
            }
        }

        public void AddError(Exception ex) => this.AddError(ex.ToInnerExceptionMessage());
    }

    public class BaseResponse<TModel> : BaseResponse, IResponse<TModel> where TModel : /* IModel */ BaseModel
    {
        public BaseResponse() : base()
        {
            this._results = new List<TModel>();
            this.Paging = new PagingResult();
        }

        [JsonIgnore]
        private /* protected */ IList<TModel> _results = null;

        public IEnumerable<TModel> Results => this._results; /* this._results.Count() != 1 ? this._results : null; */

        public TModel Result => this._results.Count() == 1 ? this._results.FirstOrDefault() : null;

        public bool AnyResult => this._results.Any();

        [JsonIgnore]
        private int? _count;

        public int Count
        {
            get => this._count.HasValue ? this._count.Value : this._results.Count();
            set => this._count = value;
        }

        public void AddResult(TModel result) => _results = _results.Concat(new TModel[] { result }).ToList();

        public void AddResult(IEnumerable<TModel> results) => _results = _results.Concat(results).ToList();

        public IPagingResponse Paging { get; set; }
    }

    public class BaseResponse<TEntity, TKey> : BaseResponse, IResponse<TEntity, TKey> where TEntity : /* IEntity<TKey> */ BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public BaseResponse() : base() { }
    }

    public class BaseResponse<TEntity, TModel, TKey> : BaseResponse<TModel>, IResponse<TEntity, TModel, TKey> where TEntity : /* IEntity<TKey> */ BaseEntity<TKey> where TModel : /* IModel<TKey> */ BaseModel<TKey> where TKey : IEquatable<TKey>
    {
        public BaseResponse() : base() { }

        public virtual void AddResult(TEntity entity) => throw new NotImplementedException();

        public virtual void AddResult(IEnumerable<TEntity> entities) => throw new NotImplementedException();
    }
}
