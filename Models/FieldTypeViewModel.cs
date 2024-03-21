using System.ComponentModel.DataAnnotations;

namespace Project_PRN221_BookingFields.Models
{
    public class FieldTypeViewModel
    {
        [Required]
        public int Id { get; set; } 
        public string Name { get; set; }
    }
}
