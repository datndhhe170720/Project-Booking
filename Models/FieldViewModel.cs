using Project_PRN221_BookingFields.Data;
using System.Xml.Linq;

namespace Project_PRN221_BookingFields.Models
{
    public class FieldViewModel
    {
        public FieldViewModel()
        {
            
        }
        public int Id { get; set; }
        public int FieldNumber { get; set; }
        public int FieldTypeId { get; set; }
        public FieldType FieldType { get; set; }
        public FieldBook Status { get; set; }
        public decimal FieldPrice { get; set; }
        public string FieldPicture { get; set; }
        public IFormFile FieldPictureFile { get; set; }
        public FieldViewModel(Field model)
        {
            Id = model.Id;
            FieldNumber = model.FieldNumber;
            FieldTypeId = model.FieldTypeId;
            Status = model.Status;
            FieldPrice = model.Price;
            FieldPicture = model.FieldPicture;
            FieldType = model.FieldType;
        }
        public Field ConvertModel(FieldViewModel vm)
        {
            return new Field() { Id = vm.Id, FieldNumber = vm.FieldNumber, FieldTypeId = vm.FieldTypeId, Status = vm.Status, Price = vm.FieldPrice, FieldPicture=vm.FieldPicture, FieldType=vm.FieldType};
        }
    }
}
