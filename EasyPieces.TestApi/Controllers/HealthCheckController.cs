﻿using EasyPieces.Attributes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyPieces.TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EasyAccess("HealthCheck")]
    public class HealthCheckController : ControllerBase
    {
        // GET: api/<HealthCheckController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
