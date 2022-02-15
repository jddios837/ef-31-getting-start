using System.ComponentModel.DataAnnotations;

namespace SamuraiApp.Domain
{
    public class Clan
    {
        public int Id { get; set; }
        
        [Required]
        public string ClanName { get; set; }
        
        public string ClanDescription { get; set; }
    }
}