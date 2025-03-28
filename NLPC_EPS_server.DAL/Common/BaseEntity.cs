﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.DAL.Common
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        [StringLength(550)]
        public string? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        [StringLength(550)]
        public string? ModifiedBy { get; set; }
    }
}
