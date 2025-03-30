using System.ComponentModel.DataAnnotations;

namespace Database_Per_Tenant.Models
{
    public class Client
    {
        [Key]
        public Guid ClientId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClientName { get; set; }

        // The connection string specific to the tenant's database.
        [Required]
        public string ConnectionString { get; set; }

        // Track when the client record was created.
        public DateTime CreatedDate { get; set; }

        public Client()
        {
            // Generate a new unique identifier for the tenant.
            ClientId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
