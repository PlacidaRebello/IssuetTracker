using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Dto
{
    public class CreateIssueRequest
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string Tags { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
    }
}
