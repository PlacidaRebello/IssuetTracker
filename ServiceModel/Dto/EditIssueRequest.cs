﻿using ServiceModel.Type;

namespace ServiceModel.Dto
{
    public class EditIssueRequest : Issue
    {
        public int IssueId { get; set; }
    }   
}
