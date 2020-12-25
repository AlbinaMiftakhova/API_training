using System.Collections.Generic;
using API_training.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_training.Controllers
{
    /// <summary>
    /// Value controller for example Authorize decorator.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = DocumentPartsConst.User)]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        /// <summary>
        /// Initialize <see cref="ValuesController"/>
        /// </summary>
        /// <param name="logger">Logger.</param>
        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Test endpoint.
        /// </summary>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var userName = User.Identity.Name;
            _logger.LogInformation($"User [{userName}] is viewing values.");
            return new[] { "value1", "value2" };
        }
    }
}
