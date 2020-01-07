using ServiceModel.Type;

namespace ServiceModel.Dto
{
    public class EditIssueStatusRequest : IssueStatus
    {
        public int IssueStatusId { get; set; }
    }
}
