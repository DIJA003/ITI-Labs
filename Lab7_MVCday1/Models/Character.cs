namespace Lab7_MVCday1.Models
{
    public class Character
    {
        public Character()
        {

        }
        public Character(int id, string name, int level)
        {
            Id = id;
            Name = name;
            Level = level;
        }
        public int Id { get;private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
       
    }
}
