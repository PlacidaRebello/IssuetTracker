using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ServiceModel.Type
{
    public class IssueType
    {
        [Required]
        public string IssueTypeName { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
