using Project_PRN221_BookingFields.Data;
using System.ComponentModel.DataAnnotations;

namespace Project_PRN221_BookingFields.Models
{
    public class FieldTypeViewModel
    {
        public FieldTypeViewModel()
        {

        }
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public FieldTypeViewModel(FieldType model)
        {
            Id = model.Id;
            Name = model.Name;
        }
        public FieldType ConvertModel(FieldTypeViewModel vm)
        {
            return new FieldType() { Id = vm.Id, Name = vm.Name };
        }
    }

}
