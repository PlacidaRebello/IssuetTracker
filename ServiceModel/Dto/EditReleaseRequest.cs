using ServiceModel.Type;

namespace ServiceModel.Dto
{
    public class EditReleaseRequest : Release
    {
        public int ReleaseId { get; set; }
    }
}
