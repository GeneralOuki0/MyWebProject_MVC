using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWebProject.Models
{
    public class Category
    {
        [Key] //this is called DATA ANNOTATION and these gives us client side validations that we check for in the controller
        public int Id { get; set; }
        [Required] //This also
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public String Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "The field Display Order must be between 1-100.")]
        public int DisplayOrder { get; set; }
    }
}
