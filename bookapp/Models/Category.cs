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
        public string Name { get; set; }
        public int Display0rder { get; set; }   
    }
}
