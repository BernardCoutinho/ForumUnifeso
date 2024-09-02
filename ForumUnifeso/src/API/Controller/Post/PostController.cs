using ForumUnifeso.src.API.Interface;
using Microsoft.AspNetCore.Mvc;
using ForumUnifeso.src.API.Model;

namespace ForumUnifeso.src.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        
        [HttpPost]
        public IActionResult CreatePost([FromBody] Post post)
        {
            if(post is null)
            {
                throw new ArgumentNullException(nameof(post));
            }

            _postService.CreatePost(post);

            return Ok();
        }
    }
}
