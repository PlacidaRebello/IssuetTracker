using System;

namespace ServiceModel.Type
{
    public class Sprint
    {
        public string SprintName { get; set; }
        public decimal SprintPoints { get; set; }
        public int SprintStatusId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public int ReleaseId { get; set; }
    }   
}
