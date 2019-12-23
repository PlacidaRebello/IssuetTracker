using ServiceModel.Type;

namespace ServiceModel.Dto
{
    public class EditIssueTypeRequest : IssueTypeType
    {
        public int IssueTypeId { get; set; }
    }
}
