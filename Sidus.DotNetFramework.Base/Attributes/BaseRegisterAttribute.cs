using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public abstract class BaseRegisterAttribute : Attribute
    {
        private Guid _id = Guid.Empty;

        public BaseRegisterAttribute(string id) : base()
        {
            this._id = Guid.Parse(id);
        }

        public Guid Id => this._id;
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RegisterControllerAttribute : BaseRegisterAttribute
    {
        public RegisterControllerAttribute(string id) : base(id)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RegisterActionAttribute : BaseRegisterAttribute
    {
        public RegisterActionAttribute(string id) : base(id)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RegisterBaseApiActionAttribute : Attribute
    {
        private string _suffix = null;

        public RegisterBaseApiActionAttribute(string suffix) : base()
        {
            this._suffix = suffix;
        }

        public string Suffix => this._suffix;
    }
}
