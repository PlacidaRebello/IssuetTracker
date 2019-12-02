using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ServiceModel.Dto
{
    public class CreateIssueRequest
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string AssignedTo { get; set; }
        [Required]
        public string Tags { get; set; }
        [Required]
        public string Status { get; set; }
        public string CreatedBy { get; set; }
    }

    public class EditIssueRequest
    {
        public int IssueId { get; set; }    
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string AssignedTo { get; set; }
        [Required]
        public string Tags { get; set; }
        [Required]
        public string Status { get; set; }
        public string CreatedBy { get; set; }
    }
}
