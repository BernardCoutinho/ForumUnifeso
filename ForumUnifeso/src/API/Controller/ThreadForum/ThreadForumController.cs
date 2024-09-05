using ForumUnifeso.src.API.Interface;
using ForumUnifeso.src.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace ForumUnifeso.src.API.Controller.ThreadForumController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThreadForumController : ControllerBase {

        private IThreadForumService _threadForumService;

        public ThreadForumController(IThreadForumService threadForumService)
        {
            _threadForumService = threadForumService;
        }

        [HttpPost]
        public IActionResult PostThreadForum([FromBody] ThreadForumDTO threadForumDTO)
        {
            try 
            {
                if (threadForumDTO is null) {
                    return BadRequest("Valor de 'Thread' é nulo");
                }

                ThreadForum threadForum = _threadForumService.PostThreadForum(threadForumDTO);              
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
                var threads = await _threadForumService.GetAllThreadForum();
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
                var thread = await _threadForumService.GetThreadForumById(id);
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
                var thread = await _threadForumService.GetThreadForumByTitle(title);
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

                await _threadForumService.PutThreadForum(threadForum);
                return NoContent();
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }


    } 
}