using Sidus.DotNet.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sidus.DotNet.Core.Entities.Test
{
    [Table("Test", Schema = "Test")]
    public class Test : BaseApplicationEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
