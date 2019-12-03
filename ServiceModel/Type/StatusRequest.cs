using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceModel.Type
{
    public class StatusRequest
    {
        [Required]
        public string StatusName { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
