using ServiceModel.Type;

namespace ServiceModel.Dto
{
    public class GetIssueData : Issue
    {
        public int IssueId { get; set; }
        public string StatusName { get; set; }
        public int IssueDetailsId { get; set; }
    }
}
