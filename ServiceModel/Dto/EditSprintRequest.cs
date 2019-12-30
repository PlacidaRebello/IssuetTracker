using ServiceModel.Type;

namespace ServiceModel.Dto
{
    public class EditSprintRequest : Sprint
    {
        public int SprintId { get; set; }
        public int SprintStatusId { get; set; }
    }
}
