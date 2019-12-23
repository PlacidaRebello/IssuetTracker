using ServiceModel.Type;

namespace ServiceModel.Dto
{
    public class EditStatusRequest : Status
    {
        public int StatusId { get; set; }
    }
}
