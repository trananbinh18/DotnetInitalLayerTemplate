using System.Threading.Tasks;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/posts")]
    public class V1PostController : ControllerBase
    {

        private readonly IPostService _postServices;
        public V1PostController(IPostService postServices)
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
