using System.ComponentModel.DataAnnotations;

namespace GamePlatform.Models
{
    public class Game
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public Currency Price { get; set; }
        public string Region { get; set; }
        public Game(string name)
        {
            Name = name;
        }
    }
}