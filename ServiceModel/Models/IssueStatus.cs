using System;

namespace ServiceModel.Models
{
    public class IssueStatus
    {
        public int IssueStatusId { get; set; }
        public string StatusName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
