using CentralLoggerSystem.Models;
using CentralLoggerSystem.Services;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices.Marshalling;

namespace CentralLoggerSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoggingController : ControllerBase
    {
        private readonly ILoggerService _loggerService;

        public LoggingController(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        [HttpPost]
        public async Task<IActionResult> LogInformaion([FromBody] string message)
        {


            await _loggerService.LogInfo(message);

            return Ok("Log sent");
        }

        [HttpPost]
        public async Task<IActionResult> LogError([FromBody] string message)
        {


            await _loggerService.LogError(message);

            return Ok("Log sent");
        }

    }
}
