using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class IssueDetails
    {
        public int IssueDetailsId { get; set; }
        public string Attachment { get; set; }
        public int Reporter { get; set; }
        public string Enviroment { get; set; }
        public string Browser { get; set; }
        public string AcceptanceCriteria { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal StoryPoints { get; set; }
        public int Epic { get; set; }
        public int UAT { get; set; }
        public bool MyProperty { get; set; }
        public string TimeTracking { get; set; }
        public int IssueId { get; set; }    
        public Issue Issue { get; set; }
    }
}
