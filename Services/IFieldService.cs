using Project_PRN221_BookingFields.Models;
using Project_PRN221_BookingFields.Utility;

namespace Project_PRN221_BookingFields.Services
{
    public interface IFieldService
    {
        PagedResult<FieldViewModel> GetAll(int pageNumber, int pageSize);
        FieldViewModel GetField(int Id);
        void UpdateField(FieldViewModel field);
        void InsertField(FieldViewModel field);
        void DeleteField(int id);
    }
}
