namespace ServiceModel.Models
{
    public class IssuePriority
    {
        public int IssuePriorityId { get; set; }
        public int IssueOrder { get; set; }
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
    }
}
