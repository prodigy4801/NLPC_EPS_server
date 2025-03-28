﻿using NLPC_EPS_server.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.DAL
{
    public class MemberProfile : BaseEntity
    {
        public int EmployeeProfileId { get; set; }
        [Required]
        [StringLength(550)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [StringLength(550)]
        public string Email { get; set; } = string.Empty;
        [StringLength(550)]
        public string? PhoneNumber { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [StringLength(550)]
        public string Address { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int? StateId { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public DateTime? DateDeleted { get; set; }

        [ForeignKey(nameof(EmployeeProfileId))]
        public EmployeeProfile EmployeeProfile { get; set; }
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }
    }
}
