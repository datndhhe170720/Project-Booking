using Microsoft.AspNetCore.Mvc;
using Project_PRN221_BookingFields.Data;
using Project_PRN221_BookingFields.Models;

namespace Project_PRN221_BookingFields.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FieldTypeController : Controller
    {
        private ApplicationDbContext _context;

        public FieldTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var fieldsTypeList = _context.FieldTypes.ToList();
            List<FieldTypeViewModel> vm = new List<FieldTypeViewModel>();
            foreach (var item in fieldsTypeList)
            {
                vm.Add(new FieldTypeViewModel { Name = item.Name });
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var fieldType = _context.FieldTypes.FirstOrDefault(x => x.Id == id);
            FieldTypeViewModel vm = new FieldTypeViewModel();
            vm.Id = fieldType.Id;
            vm.Name = fieldType.Name;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(FieldTypeViewModel vm)
        {
            var fieldType = _context.FieldTypes.FirstOrDefault(x => x.Id == vm.Id);
            fieldType.Name = vm.Name;
            _context.FieldTypes.Update(fieldType);
            _context.SaveChanges();
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
            FieldType model = new FieldType();
            model.Name = vm.Name;
            _context.FieldTypes.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var fieldType = _context.FieldTypes.FirstOrDefault(x => x.Id == id);
            _context.FieldTypes.Remove(fieldType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
