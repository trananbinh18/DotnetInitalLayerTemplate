using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {

        private readonly IPostServices _postServices;
        public PostController(IPostServices postServices)
        {
            _postServices = postServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostsAsync([FromQuery] string searchText = "")
        {
            var response = await _postServices.GetPostsAsync(searchText);
            return Ok(response);
        }


    }
}
