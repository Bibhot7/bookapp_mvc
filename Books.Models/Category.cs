using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bookapp.Models
{
    public class Category
    {
        //Id is the primary key of the table.
        //Data annotation.
        [Key]
        public int Id { get; set; }
        [Required]
        //adding validation server side.
        [MaxLength(30)]
        [DisplayName("Category Name")]

        public required string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order must be between 1-100")]
        //adding validation server side and displaying the custom error message.
        public int Display0rder { get; set; }
    }
}
