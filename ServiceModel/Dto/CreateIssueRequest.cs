using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using ServiceModel.Type;

namespace ServiceModel.Dto
{
    public class CreateIssueRequest : IssueRequest
    {
       
    }

    public class EditIssueRequest: IssueRequest
    {
        public int IssueId { get; set; }    
        
    }
}
