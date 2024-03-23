using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_PRN221_BookingFields.Models;
using Project_PRN221_BookingFields.Services;
using Project_PRN221_BookingFields.Utility;
using System.Drawing.Printing;

namespace Project_PRN221_BookingFields.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FieldsController : Controller
    {
        IWebHostEnvironment env;
        private IFieldService _fieldService;
        private IFieldTypeService _fieldTypeService;
        

        public FieldsController(IFieldService fieldService, IWebHostEnvironment env, IFieldTypeService fieldTypeService)
        {
            _fieldService = fieldService;
            this.env = env;
            _fieldTypeService = fieldTypeService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 6)
        {
            PagedResult<FieldViewModel> vm = _fieldService.GetAll(pageNumber, pageSize);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _fieldService.GetField(id);
            return View();
        }
        [HttpPost]
        public IActionResult Edit(FieldViewModel vm)
        {

            _fieldService.UpdateField(vm);  
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.FieldType = new SelectList(_fieldTypeService.AllFieldsType(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(FieldViewModel vm)
        {

            if (vm.FieldPictureFile!= null)
            {
                ImageOperations image = new ImageOperations(env);
                string ImageFileName = image.UploadImage(vm);
                vm.FieldPicture = ImageFileName;
            }
            else
            {
                vm.FieldPicture = "~/Images/Fielddemo.jpg";
            }

            _fieldService.InsertField(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            _fieldService.DeleteField(id);
            return RedirectToAction("Index");
        }
    }
}
