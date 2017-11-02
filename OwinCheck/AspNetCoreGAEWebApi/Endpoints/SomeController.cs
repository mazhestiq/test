using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreGAEWebApi.Endpoints
{
    [Route("api/v1/[controller]")]
    public class SomeController : Controller
    {
        private readonly ILogger<SomeController> _logger;

        public SomeController(ILogger<SomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public bool Get()
        {
            _logger.LogInformation("hello from 'get' in 'some controller'");

            return true;
        }
    }
}
