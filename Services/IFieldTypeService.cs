using Project_PRN221_BookingFields.Models;
using Project_PRN221_BookingFields.Utility;

namespace Project_PRN221_BookingFields.Services
{
    public interface IFieldTypeService
    {
        PagedResult<FieldTypeViewModel> GetAllFieldsType(int pageNumber, int pageSize);
        IEnumerable<FieldTypeViewModel> AllFieldsType();
        FieldTypeViewModel GetFieldType(int TypeId);
        void UpdateFieldType(FieldTypeViewModel fieldType);
        void InsertFieldType(FieldTypeViewModel fieldType);
        void DeleteFieldType(int id);
    }
}
