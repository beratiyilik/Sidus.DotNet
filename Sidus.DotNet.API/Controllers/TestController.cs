using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sidus.DotNet.API.Controllers.Base;
using Sidus.DotNet.Core.Contracts.Services.Test;
using Sidus.DotNet.Core.Entities.Test;
using Sidus.DotNet.Core.Models.Test;
using Sidus.DotNetFramework.Base.Attributes;
using System;

namespace Sidus.DotNet.API.Controllers
{
    [RegisterController("CFFFD5C0-D243-47CA-88CB-49C57AFBC62F")]
    [Route("api/[controller]/[action]")]
    public class TestController : ApplicationApiController<Test, TestModel>
    {
        readonly private ITestService _testService;
        public TestController(ITestService testService) : base(testService)
        {
            _testService = testService ?? throw new ArgumentNullException(nameof(testService));
        }

        [RegisterAction("0812B2EE-2125-40A8-9677-3B3ECEABB00C")]
        [HttpGet]
        public IActionResult Hede()
        {
            var res = this._testService.GetAsEnumerable(m => m.State == DotNetFramework.Base.Enums.Enums.EntityState.Active);
            return Ok(res);
        }

        [RegisterAction("D0588AF2-C386-4C2C-B28E-4025DDB76E54")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override IActionResult Get(Guid id)
        {
            return base.Get(id);
        }
    }
}
