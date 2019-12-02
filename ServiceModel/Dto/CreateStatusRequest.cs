using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceModel.Dto
{
    public class CreateStatusRequest
    {
      //  public int StatusId { get; set; }
        [Required]
        public string StatusName { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }

    public class EditStatusRequest 
    {
        public int StatusId { get; set; }
        [Required]
        public string StatusName { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
