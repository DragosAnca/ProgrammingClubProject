using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgrammingClubProject.Models
{
    public class MembershipModel
    {
        public Guid IDMembership { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Guid IDMember { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Guid IDMembershipType { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime? EndDate { get; set; }
        public int Level { get; set; }

    }
}