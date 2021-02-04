using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class BaseAreaAttribute : AreaAttribute
    {
        private Guid _id = Guid.Empty;

        public BaseAreaAttribute(string id, string areaName) : base(areaName)
        {
            this._id = Guid.Parse(id);
        }

        public Guid Id => this._id;
    }
}
