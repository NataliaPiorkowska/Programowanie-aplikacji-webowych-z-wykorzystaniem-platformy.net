using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesProject.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public string Client { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string Country { get; set; } = string.Empty;
    }
}
