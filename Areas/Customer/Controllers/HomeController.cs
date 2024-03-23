using Microsoft.AspNetCore.Mvc;
using Project_PRN221_BookingFields.Models;
using Project_PRN221_BookingFields.Services;
using Project_PRN221_BookingFields.Utility;
using System.Drawing.Printing;

namespace Project_PRN221_BookingFields.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        private IFieldService _fieldService;
        private IFieldTypeService _fieldTypeService;

        public HomeController(IFieldService fieldService, IFieldTypeService fieldTypeService)
        {
            _fieldService = fieldService;
            _fieldTypeService = fieldTypeService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 6)
        {
            PagedResult<FieldViewModel> vm = _fieldService.GetAll(pageNumber, pageSize);
            return View(vm);
        }
    }
}
