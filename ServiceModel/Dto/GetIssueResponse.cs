using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Dto
{
    public class GetIssueResponse
    {
        public int IssueId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string Tags { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; }
    }
}
