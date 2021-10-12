using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgrammingClubProject.Models
{
    public class CodeSnippetModel
    {
        public Guid IDCodeSnippet { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "String is too long (max 50)!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "String is too long (max 250)!")]
        public string ContentCode { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public Guid IDMember { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public int Revision { get; set; }

        //public Guid IDSnippetPreviousVersion { get; set; }
       // public DateTime DateTimeAdded { get; set; }
        //public bool IsPublished { get; set; }
    }
}