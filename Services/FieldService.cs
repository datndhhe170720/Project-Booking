using Microsoft.VisualBasic.FileIO;
using NuGet.Protocol;
using Project_PRN221_BookingFields.Data;
using Project_PRN221_BookingFields.Models;
using Project_PRN221_BookingFields.Repository;
using Project_PRN221_BookingFields.Utility;

namespace Project_PRN221_BookingFields.Services
{
    public class FieldService : IFieldService
    {
        private IUnitOfWork _unitOfWordk;
        ILogger<FieldService> _iLogger;

        public FieldService(IUnitOfWork unitOfWordk, ILogger<FieldService> iLogger)
        {
            _unitOfWordk = unitOfWordk;
            _iLogger = iLogger;
        }

        public void DeleteField(int id)
        {
            var field = _unitOfWordk.GenericRepository<Field>().GetById(id);
            _unitOfWordk.GenericRepository<Field>().Delete(field);
            _unitOfWordk.Save();
        }

        public PagedResult<FieldViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new FieldViewModel();
            List<FieldViewModel> vmList = new List<FieldViewModel>();
            int totalCount;
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var fields = _unitOfWordk.GenericRepository<Field>().GetAll(includeProperties: "FieldType").Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWordk.GenericRepository<Field>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModeList(fields);


            }
            catch (Exception ex)
            {
                throw;
            }
            var result = new PagedResult<FieldViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };
            return result;
        }

        private List<FieldViewModel> ConvertModelToViewModeList(List<Field> fields)
        {
            return fields.Select(x => new FieldViewModel(x)).ToList();
        }

        public FieldViewModel GetField(int Id)
        {
            var fields = _unitOfWordk.GenericRepository<Field>().GetById(Id);
            var vm = new FieldViewModel(fields);
            return vm;
        }

        public void InsertField(FieldViewModel field)
        {
            var model = new FieldViewModel().ConvertModel(field);
            _unitOfWordk.GenericRepository<Field>().Add(model);
            _unitOfWordk.Save();
        }

        public void UpdateField(FieldViewModel field)
        {
            var model = new FieldViewModel().ConvertModel(field);
            _unitOfWordk.GenericRepository<Field>().Update(model);
            _unitOfWordk.Save();
        }
    }
}
