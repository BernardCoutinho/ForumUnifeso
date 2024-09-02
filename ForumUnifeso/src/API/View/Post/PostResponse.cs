using ForumUnifeso.src.API.Model;
using System.ComponentModel.DataAnnotations;

namespace ForumUnifeso.src.API.View
{
    public class PostResponse
    {
        public string Title { get; private set; }
       
        public string Description { get; private set; }
        public DateTime Date { get; private set; }

        public PersonResponse Author { get; private set; }
    }
}
