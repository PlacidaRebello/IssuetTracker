using System;

namespace ServiceModel.Type
{
    public class Release
    {
        public string ReleaseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
