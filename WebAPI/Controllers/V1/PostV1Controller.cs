using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/post/v1")]
    public class PostV1Controller : ControllerBase
    {

        private readonly IPostServices _postServices;
        public PostV1Controller(IPostServices postServices)
        {
            _postServices = postServices;
        }

        /// <summary>
        /// Get all posts
        /// </summary>
        /// <remarks>
        /// **Details:**
        /// - Get all available posts 
        /// </remarks>
        /// <param name="searchText">Search this text on post titles</param>
        /// <returns>Return a list of posts</returns>
        [HttpGet]
        public async Task<IActionResult> GetPostsAsync([FromQuery] string searchText = "")
        {
            var response = await _postServices.GetPostsAsync(searchText);
            return Ok(response);
        }


    }
}
