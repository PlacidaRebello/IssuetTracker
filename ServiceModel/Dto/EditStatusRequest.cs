using ServiceModel.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Dto
{
    public class EditStatusRequest : Status
    {
        public int StatusId { get; set; }
    }
}
