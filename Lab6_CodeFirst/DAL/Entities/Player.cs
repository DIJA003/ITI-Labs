namespace Lab6_CodeFirst.DAL.Entities
{
    public class Player
    {
        public int playerID{ get; private set; }
        public string name{ get; private set; }
        public string email{ get; private set; }
        public string password{ get; private set; }
        public bool is_deleted{ get; private set; }
    }
}
