namespace ForumUnifeso.src.API.Model
{
    public class Post
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Date{ get; private set; }

        public int AuthorId { get; private set; } 
        public Person Author { get; private set; }
    }
}
