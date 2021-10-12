using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgrammingClubProject.Models
{
    public class MemberModel
    {
        public Guid IDMember { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "String is too long (max 50)!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "String is too long (max 50)!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "String is too long (max 50)!")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "String is too long (max 250)!")]
        public string Description { get; set; }
        public string Resume { get; set; }
       
    }
}