using ServiceModel.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Dto
{
    public class GetIssueResponse: IssueRequest
    {
        public int IssueId { get; set; }
    }
}
