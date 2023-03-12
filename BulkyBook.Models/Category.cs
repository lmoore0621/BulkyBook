using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(0, 100, ErrorMessage = "This value is out of range!")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        [DisplayName("Create Date")]
        public DateTime CreatedDateTime { get; set; }
    }
}