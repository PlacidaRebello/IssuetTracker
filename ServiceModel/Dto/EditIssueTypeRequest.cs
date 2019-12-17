using ServiceModel.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Dto
{
    public class EditIssueTypeRequest: IssueType
    {
        public int IssueTypeId { get; set; }
    }
}
