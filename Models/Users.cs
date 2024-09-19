using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Users
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
