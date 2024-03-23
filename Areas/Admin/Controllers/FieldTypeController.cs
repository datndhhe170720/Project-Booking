using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_PRN221_BookingFields.Data;
using Project_PRN221_BookingFields.Models;
using Project_PRN221_BookingFields.Utility;
using Project_PRN221_BookingFields.Repository;
using Project_PRN221_BookingFields.Services;

namespace Project_PRN221_BookingFields.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FieldTypeController : Controller
    {
        private IFieldTypeService _fieldType;
        //private IUnitOfWork _unitOfWork;

        public FieldTypeController(IFieldTypeService fieldType)
        {
            _fieldType = fieldType;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 6)
        {
            //_unitOfWork.GenericRepository<FieldType>().GetAll();
            //var fieldsTypeList = _context.FieldTypes.ToList();
            //List<FieldTypeViewModel> vm = new List<FieldTypeViewModel>();
            //foreach (var item in fieldsTypeList)
            //{
            //    vm.Add(new FieldTypeViewModel { Name = item.Name });
            //}

            PagedResult<FieldTypeViewModel> vm = _fieldType.GetAllFieldsType(pageNumber,pageSize);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var fieldType = _context.FieldTypes.FirstOrDefault(x => x.Id == id);
            //FieldTypeViewModel vm = new FieldTypeViewModel();
            //vm.Id = fieldType.Id;
            //vm.Name = fieldType.Name;

            var viewModel = _fieldType.GetFieldType(id);
            return View();
        }
        [HttpPost]
        public IActionResult Edit(FieldTypeViewModel vm)
        {

            _fieldType.UpdateFieldType(vm);

            //var fieldType = _context.FieldTypes.FirstOrDefault(x => x.Id == vm.Id);
            //fieldType.Name = vm.Name;
            //_context.FieldTypes.Update(fieldType);
            //_context.SaveChanges();     
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(FieldTypeViewModel vm)
        {

            _fieldType.InsertFieldType(vm);

            //FieldType model = new FieldType();
            //model.Name = vm.Name;
            //_context.FieldTypes.Add(model);
            //_context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            _fieldType.DeleteFieldType(id);

            //var fieldType = _context.FieldTypes.FirstOrDefault(x => x.Id == id);
            //_context.FieldTypes.Remove(fieldType);
            //_context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
