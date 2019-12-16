using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using ServiceModel.Type;

namespace ServiceModel.Dto
{
    public class CreateIssueRequest : Issue
    {
       
    }

    public class EditIssueRequest: Issue
    {
        public int IssueId { get; set; }    
        
    }
}
