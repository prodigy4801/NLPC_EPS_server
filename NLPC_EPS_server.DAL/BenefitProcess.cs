using NLPC_EPS_server.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.DAL
{
    public class BenefitProcess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string ProcessCode { get; set; }
        [StringLength(550)]
        public string? Description { get; set; }

        public virtual ICollection<BenefitRequest> BenefitRequests { get; set; }
    }
    //-> PENDING -> VERIFICATION -> DENIED -> DISPATCHED
}
