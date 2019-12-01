using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Dto
{
    public class CreateStatusRequest
    {
        //public int StatusId { get; set; }

        public string StatusName { get; set; }

        public string CreatedBy { get; set; }
    }
}
