using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Models
{
    public class Category
    {
        [Key] //this is called DATA ANNOTATION
        public int Id { get; set; }
        [Required] //This also
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public String Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
    }
}
