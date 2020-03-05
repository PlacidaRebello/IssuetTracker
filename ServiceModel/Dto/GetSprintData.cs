using ServiceModel.Type;

namespace ServiceModel.Dto
{
    public class GetSprintData : Sprint
    {
        public int SprintId { get; set; }
        public string SprintStatusName { get; set; }
    }
}
