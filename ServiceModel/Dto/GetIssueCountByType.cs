using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Dto
{
    public class GetIssueCountByType
    {
        public string TypeName { get; set; }
        public int IssueCount { get; set; }
    }
}
