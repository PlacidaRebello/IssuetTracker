using System;

namespace DataAccess.Models
{
    public class IssueType
    {
        public int IssueTypeId { get; set; }
        public string IssueTypeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
