namespace ForumUnifeso.src.API.Model
{
    public class Post
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Date{ get; private set; }

        public Person Author { get; private set; }
        public int AuthorId { get; private set; }


        public int? ThreadForumId { get; private set; }
        public ThreadForum ThreadForum { get; private set; }

        public Post() {}
        public Post(int id, string title, string description, DateTime date, Person author) 
        {
            Id = id;
            Title = title;
            Description = description;
            Date = date;
            Author = author;
        }
    }
}
