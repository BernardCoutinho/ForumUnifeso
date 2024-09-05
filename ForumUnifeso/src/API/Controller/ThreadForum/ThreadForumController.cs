using ForumUnifeso.src.API.Interface;
using ForumUnifeso.src.API.Model;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThreadForum>>> GetAllThreadForum() 
        {
            try
            {
                var threads = await _threadForum.GetAllThreadForum();
                return Ok(threads);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ThreadForum>> GetThreadForumById(int id)
        {
            try
            {
                var thread = await _threadForum.GetThreadForumById(id);
                if (thread == null) {
                    return NotFound();
                }
                return Ok(thread);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("title/{title}")]
        public async Task<ActionResult<ThreadForum>> GetThreadForumByTitle(string title)
        {
            try
            {
                var thread = await _threadForum.GetThreadForumByTitle(title);
                if (thread == null) {
                    return NotFound();
                }
                return Ok(thread);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutThreadForum([FromBody] ThreadForum threadForum)
        {
            try
            {
                if (threadForum == null) {
                    return BadRequest();
                }

                await _threadForum.PutThreadForum(threadForum);
                return NoContent();
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }


    } 
}