using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic.Factory
{
    public static class IssuesFactory
    {
        public static IIssue GetIssueManager(int issueTypeId,IIssuesEngine issuesEngine) 
        {
            IIssue issueObj = null;
            //random Id values considerd
            if (issueTypeId==3)
            {
                issueObj = new Bug(issuesEngine);
            }
            else if (issueTypeId == 4)
            {
                issueObj = new Story(issuesEngine);
            }
            else if (issueTypeId == 5)
            {
                issueObj = new Tasks(issuesEngine);
            }
            
            return issueObj;          

        }
    }
}
