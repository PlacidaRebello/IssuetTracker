using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceModel.Models
{
    public class IssueDetails
    {
        public int IssueDetailsId { get; set; }
        public string Attachment { get; set; }
        [Column("Reporter")]
        public string UserId { get; set; }
        public string User { get; set; }
        public string Enviroment { get; set; }
        public string Browser { get; set; }
        public string AcceptanceCriteria { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal StoryPoints { get; set; }
        public int Epic { get; set; }
        public bool UAT { get; set; }
        public string TimeTracking { get; set; }
        public int IssueId { get; set; }    
        public Issue Issue { get; set; }
    }
}
