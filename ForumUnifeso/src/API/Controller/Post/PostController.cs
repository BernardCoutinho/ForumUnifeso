using ForumUnifeso.src.API.Interface;
using Microsoft.AspNetCore.Mvc;
using ForumUnifeso.src.API.Model;
using ForumUnifeso.src.API.View;
using AutoMapper;

namespace ForumUnifeso.src.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult CreatePost([FromBody] PostRequest postRequest)
        {
            if(postRequest is null)
            {
                return BadRequest("Post data is null.");
            }

            try
            {
                Post post = _mapper.Map<Post>(postRequest);

                _postService.CreatePost(post);

                PostResponse response = _mapper.Map<PostResponse>(post);
                return Ok(response);
            }
            catch (AutoMapperMappingException ex)
            {
                return StatusCode(500, "Mapping configuration issue.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }
    }
}
