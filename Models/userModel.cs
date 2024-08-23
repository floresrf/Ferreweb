using System.ComponentModel.DataAnnotations;

namespace Ferreweb.Models
{
    public class userModel
    {
        [Key]
        public int ID { get; set; }

        [StringLength(30)]
        public string? FirstName { get; set; }

        [StringLength(30)]
        public string? LastName { get; set; }

        [StringLength(10)]
        public string? PhoneNumber { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Password { get; set; }

    }
}