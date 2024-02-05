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
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        //adding validation server side.
        public int Display0rder { get; set; }   
    }
}
