using Project_PRN221_BookingFields.Models;
using Project_PRN221_BookingFields.Data;
using Project_PRN221_BookingFields.Repository;
using Project_PRN221_BookingFields.Utility;
using System.Drawing.Printing;

namespace Project_PRN221_BookingFields.Services
{
    public class FieldTypeService : IFieldTypeService
    {
        private IUnitOfWork _unitOfWordk;
        ILogger<FieldTypeService> _iLogger;

        public FieldTypeService(IUnitOfWork unitOfWordk, ILogger<FieldTypeService> iLogger)
        {
            _unitOfWordk = unitOfWordk;
            _iLogger = iLogger;
        }

        public void DeleteFieldType(int id)
        {
            var fieldType = _unitOfWordk.GenericRepository<FieldType>().GetById(id);
            _unitOfWordk.GenericRepository<FieldType>().Delete(fieldType);
            _unitOfWordk.Save();
        }

        public PagedResult<FieldTypeViewModel> GetAllFieldsType(int pageNumber, int pageSize)
        {
            var vm = new FieldTypeViewModel();
            List<FieldTypeViewModel> vmList = new List<FieldTypeViewModel>();
            int totalCount;
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                
                var fieldTypes = _unitOfWordk.GenericRepository<FieldType>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWordk.GenericRepository<FieldType>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModeList(fieldTypes);

               
            }
            catch (Exception ex)
            {
                throw;
            }
            var result = new PagedResult<FieldTypeViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
            }; 
            return result;
        }

        public IEnumerable<FieldTypeViewModel> AllFieldsType()
        {
            
            List<FieldTypeViewModel> vmList = new List<FieldTypeViewModel>();
            try
            {
                var fieldTypes = _unitOfWordk.GenericRepository<FieldType>().GetAll().ToList();
                vmList = ConvertModelToViewModeList(fieldTypes);

            }
            catch (Exception)
            {
                throw;
            }
            return vmList;
        }

        public FieldTypeViewModel GetFieldType(int TypeId)
        {
            var fieldType = _unitOfWordk.GenericRepository<FieldType>().GetById(TypeId);
            var vm = new FieldTypeViewModel(fieldType);
            return vm;
        }

        public void InsertFieldType(FieldTypeViewModel fieldType)
        {
            var model = new FieldTypeViewModel().ConvertModel(fieldType);
            _unitOfWordk.GenericRepository<FieldType>().Add(model);
            _unitOfWordk.Save();
        }

        public void UpdateFieldType(FieldTypeViewModel fieldType)
        {
            var model = new FieldTypeViewModel().ConvertModel(fieldType);
            _unitOfWordk.GenericRepository<FieldType>().Update(model);
            _unitOfWordk.Save();
        }

        private List<FieldTypeViewModel> ConvertModelToViewModeList(IEnumerable<FieldType> fieldTypes)
        {
            return fieldTypes.Select(x => new FieldTypeViewModel(x)).ToList();
        }
    }
}
