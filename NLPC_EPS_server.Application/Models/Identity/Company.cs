using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLPC_EPS_server.Application.Models.Identity
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(550)]
        public string Address { get; set; } = string.Empty;
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
