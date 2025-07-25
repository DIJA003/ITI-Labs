using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;

namespace Lab7_MVCday1.Models
{
    public class Player
    {
        public Player() { }
        public Player(string name,int age, string email,string password,string createdby)
        {
            Name = name;
            Email = email;
            Age = age;
            Password = password;
            CreatedBy = createdby;
            CreatedOn = DateTime.Now;
            Is_Deleted = false;
        }

        public int PlayerID { get; private set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public string Password { get; private set; }
        public bool? Is_Deleted { get; private set; }
        //public DateTime? DeletedOn { get; private set; }
        public DateTime? CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get;private set; }
        public string CreatedBy { get; private set; }
        [ForeignKey("Character")]
        public int? CharcId { get; private set; }
        public Character? Character { get; private set; }

        public void Delete()
        {
            Is_Deleted = true;
            //DeletedOn = DateTime.Now;
        }
        public void Edit(string name, int age, string email, string password)
        {
            Name = name;
            Email = email;
            Age = age;
            Password = password;
            UpdatedOn = DateTime.Now;
        }

    }
}
