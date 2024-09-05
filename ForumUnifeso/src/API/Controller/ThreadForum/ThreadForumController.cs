using System.CodeDom.Compiler;
using ForumUnifeso.src.API.Interface;
using ForumUnifeso.src.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ForumUnifeso.src.API.Controller.ThreadForumController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThreadForumController : ControllerBase {

        private IThreadForumService _threadForum;
        // private ThreadForumRepository _threadForumRepository;

        public ThreadForumController(IThreadForumService threadForum)
        {
            _threadForum = threadForum;
        }

        [HttpPost]
        public IActionResult CreateThread([FromBody] ThreadForumDTO threadForumDTO)
        {
            try 
            {
                if (threadForumDTO is null) {
                    return BadRequest("Valor de 'Thread' é nulo");
                }
                // Person author = new Person(1, threadForumDTO.AuthorName);
                // Post topic = new Post(1, threadForumDTO.Title, threadForumDTO.Description, DateTime.Now , author);
                // ThreadForum threadForum = new ThreadForum(1, topic);
                // _threadForumRepository.dsa(threadForum);
                ThreadForum threadForum = new ThreadForum();
                return Created("GetThreadForum", threadForum);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("/all")]
        public async Task<ActionResult<IEnumerable<ThreadForum>>> GetAllThreads() {
            // async 
            return new List<ThreadForum> {};
        }
    } 
}