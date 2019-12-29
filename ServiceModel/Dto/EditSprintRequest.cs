using ServiceModel.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Dto
{
    public class EditSprintRequest : Sprint
    {
        public int SprintId { get; set; }
        public int SprintStatusId { get; set; } 
    }   
}
