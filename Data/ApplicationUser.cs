using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_PRN221_BookingFields.Data
{
    public class ApplicationUser : IdentityUser
    {

        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        public string? Address { get; set; }

    }
}
