using System.ComponentModel.DataAnnotations;

namespace Ferreweb.Models
{
    public class productModel
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(30)]
        public string? Price { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }

        public string? Picture { get; set; }
    }
}
