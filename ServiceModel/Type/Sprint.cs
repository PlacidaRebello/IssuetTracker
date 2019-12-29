using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Type
{
    public  class Sprint
    {
        public string SprintName { get; set; }  
        public decimal SprintPoints { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        // public int SprintStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
