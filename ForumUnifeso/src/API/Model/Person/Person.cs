﻿namespace ForumUnifeso.src.API.Model
{
    public class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public List<Post> Posts { get; private set; } = new List<Post>();
    }
}
