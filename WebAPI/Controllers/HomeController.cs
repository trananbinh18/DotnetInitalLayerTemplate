using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Version()
        {
            var version = $"{_configuration.GetSection("Env").Get<string>()} {_configuration.GetSection("Version").Get<string>()}";
            return Ok(version);
        }


    }
}
