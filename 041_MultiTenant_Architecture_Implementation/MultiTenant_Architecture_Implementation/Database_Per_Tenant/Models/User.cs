using System.Security.Principal;

namespace Database_Per_Tenant.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
