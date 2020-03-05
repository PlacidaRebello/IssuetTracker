using ServiceModel.Type;

namespace ServiceModel.Dto
{
    public class GetReleaseData : Release
    {
        public int ReleaseId { get; set; }
        public string SprintStatusName { get; set; }
    }
}
