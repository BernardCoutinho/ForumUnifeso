using ForumUnifeso.src.API.View;
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
        public async Task<IActionResult> PostThreadForum([FromBody] ThreadForumDTO threadForumRequest)
        {
            try 
            {
                if (threadForumRequest is null) {
                    return BadRequest("Valor de 'Thread' é nulo");
                }

                ThreadForumDTO threadForumRespose = await _threadForumService.AddAsync(threadForumRequest);              
                return Created("GetThreadForum", threadForumRespose);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("/all")]
        public async Task<ActionResult<IEnumerable<ThreadForum>>> GetAllThreadForum() 
        {
            try
            {
                var threads = await _threadForumService.GetAllAsync();
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
                var thread = await _threadForumService.GetByIdAsync(threadForumId);
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
                var thread = await _threadForumService.GetByTitleAsync(title);
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
        public async Task<ActionResult<ThreadForum>> PutThreadForum(ThreadForumDTO threadForumRequest)
        {
            try
            {      
                var threadForumUpdated = await _threadForumService.UpdateAsync(threadForumRequest);
                return Ok(threadForumUpdated);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/remove/{id}")]
        public async Task<ActionResult<ThreadForum>> DeleteThreadForumById(int threadForumId)
        {
            try
            {                       
                var threadForumDeleted = await _threadForumService.DeleteByIdAsync(threadForumId);
                return Ok(threadForumDeleted);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    } 
}