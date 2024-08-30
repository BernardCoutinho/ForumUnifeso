namespace ForumUnifeso.src.API.Model.Post
{
    using ForumUnifeso.src.API.Model.Person;
    public class Post
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Date{ get; private set; }
        public Person Author{ get; private set; }
    }
}
