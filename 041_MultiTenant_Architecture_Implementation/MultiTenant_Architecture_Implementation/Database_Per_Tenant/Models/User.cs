using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Database_Per_Tenant.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
