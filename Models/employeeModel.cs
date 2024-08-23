using System.ComponentModel.DataAnnotations;

namespace Ferreweb.Models
{
    public class employeeModel
    {
        [Key]
        public int ID { get; set; }

        [StringLength(30)]
        public string? FirstName { get; set; }

        [StringLength(30)]
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        public string? BDate { get; set; }

        [StringLength(10)]
        public string? PhoneNumber { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(250)]
        public string? Direction { get; set; }

        [StringLength(12)]
        public string? Salary { get; set; }
    }
}
