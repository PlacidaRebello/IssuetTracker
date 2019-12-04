using ServiceModel.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Dto
{
    public class GetIssueTypeData:IssueTypeRequest
    {
        public int IssueTypeId { get; set; }
    }
}
