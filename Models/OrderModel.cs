using System.ComponentModel.DataAnnotations;

namespace Ferreweb.Models
{
    public class orderModel
    {
        [Key]
        public int OrderID { get; set; }


        public string? ProductID { get; set; }
        [StringLength(50)]
        public string? Product { get; set; }
        public string? Quantity { get; set; }
        [StringLength(12)]
        public string? Total_Price { get; set; }


        public string? UserID { get; set; }
        [StringLength(30)]
        public string? U_FirstName { get; set; }
        [StringLength(30)]
        public string? U_LastName { get; set; }
        public string? U_Phone { get; set; }
        [StringLength(300)]
        public string? Direction { get; set; }


        public string? EmployeeID { get; set; }
        [StringLength(30)]
        public string? E_FirstName { get; set; }
        [StringLength(30)]
        public string? E_LastName { get; set; }
    }
}
