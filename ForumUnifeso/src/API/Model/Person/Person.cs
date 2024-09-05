namespace ForumUnifeso.src.API.Model
{
    public class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        
        public Person(int id, string name) {
            Id = id;
            Name = name;
        }
    }
}
