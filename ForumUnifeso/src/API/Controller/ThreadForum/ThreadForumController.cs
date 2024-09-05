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

        [HttpPost("/add")]
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

        [HttpGet("/all")]
        public async Task<ActionResult<IEnumerable<ThreadForum>>> GetAllThreadForum() 
        {
            try
            {
                var threads = await _threadForumService.GetAllThreadsForum();
                return Ok(threads);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ThreadForum>> GetThreadForumById(int threadForumId)
        {
            try
            {
                var thread = await _threadForumService.GetThreadForumById(threadForumId);
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

        [HttpPut("/edit/{id}")]
        public async Task<ActionResult<ThreadForum>> PutThreadForum(int threadForumId)
        {
            try
            {      
                var threadForumUpdated = await _threadForumService.PutThreadForum(threadForumId);
                return Ok(threadForumUpdated);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/remove/{id}")]
        public async Task<ActionResult<ThreadForum>> DeleteThreadForum(int threadForumId)
        {
            try
            {                       
                var threadForumDeleted = await _threadForumService.DeleteThreadForum(threadForumId);
                return Ok(threadForumDeleted);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    } 
}