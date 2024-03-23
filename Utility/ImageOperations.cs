using Microsoft.AspNetCore.Hosting;
using Project_PRN221_BookingFields.Data;
using Project_PRN221_BookingFields.Models;

namespace Project_PRN221_BookingFields.Utility
{
    public class ImageOperations
    {
        private IWebHostEnvironment _webHostEnvironment;

        public ImageOperations(IWebHostEnvironment webHostEnvironment)
        {

            _webHostEnvironment = webHostEnvironment;

        }
        public string UploadImage(FieldViewModel vm)
        {
            string filename = null;
            if (vm.FieldPictureFile != null)
            {
                string UploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                filename = Guid.NewGuid().ToString() + vm.FieldPictureFile.FileName;
                string filePath = Path.Combine(UploadDir, filename);
                using (FileStream ms = new FileStream(filePath, FileMode.Create))
                {
                    vm.FieldPictureFile.CopyTo(ms);
                }
            }
            return filename;
        }
    }
}
