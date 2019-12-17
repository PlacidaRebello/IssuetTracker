using ServiceModel.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Dto
{
    public class EditIssueRequest : Issue
    {
        public int IssueId { get; set; }
    }
}
