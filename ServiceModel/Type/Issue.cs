using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceModel.Type
{
    public class Issue
    {
        [Required]
        public string Subject { get; set; }
        public string Description { get; set; }
        [Required]
        public string AssignedTo { get; set; }
        public string Tags { get; set; }
        [Required]
        public int IssueStatusId { get; set; }
        public string CreatedBy { get; set; }   
        public int Order { get; set; }
        public int IssueTypeId { get; set; }    
        public int SprintId { get; set; }
        //details
        public string Attachment { get; set; }
        public string Reporter { get; set; }
        public string Enviroment { get; set; }
        public string Browser { get; set; }
        public string AcceptanceCriteria { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal StoryPoints { get; set; }
        public int Epic { get; set; }
        public bool UAT { get; set; }
        public string TImeTracking { get; set; }
    }   
}
