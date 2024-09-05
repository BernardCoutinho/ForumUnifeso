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
        public IActionResult CreateThreadForum([FromBody] ThreadForumDTO threadForumDTO)
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
        public ActionResult<IEnumerable<ThreadForum>> GetAllThreadForum() => _threadForumService.GetAllThreadForum();
    } 
}