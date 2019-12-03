using ServiceModel.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceModel.Dto
{
    public class CreateStatusRequest: StatusRequest
    {
     
    }

    public class EditStatusRequest : StatusRequest
    {
        public int StatusId { get; set; }
        
    }
}
