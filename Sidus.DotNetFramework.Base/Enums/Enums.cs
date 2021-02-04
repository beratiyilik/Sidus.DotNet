using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Enums
{
    public static class Enums
    {
        [Description("Entity State")]
        public enum EntityState
        {
            [Description("None")]
            Null = 0,
            [Description("Active")]
            Active = 1,
            [Description("Passive")]
            Passive = 2,
            [Description("Deleted")]
            Deleted = 3
        }

        [Description("Operation Result")]
        public enum OperationResult
        {
            [Display(Description = "Initial Value", Name = "None")]
            [Description("None")]
            Null = 0,
            [Display(Description = "The Operation Failed!", Name = "Error")]
            [Description("Error")]
            Error = 1,
            [Display(Description = "", Name = "Warning")]
            [Description("Warning")]
            Warning = 2,
            [Display(Description = "", Name = "Info")]
            [Description("Info")]
            Info = 3,
            [Display(Description = "The operation completed successfully", Name = "Success")]
            [Description("Success")]
            Success = 4
        }

        [Description("Entity Type")]
        public enum EntityType
        {
            [Description("None")]
            Null = 0,
            [Description("Natural Person")]
            NaturalPerson = 1,
            [Description("Legal Entity")]
            LegalEntity = 2,
            [Description("Virtual")]
            Virtual = 3
        }
    }
}
