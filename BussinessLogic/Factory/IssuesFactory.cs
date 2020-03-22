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
        public static IIssue CreateIssue(int issueTypeId,IIssuesEngine issuesEngine) 
        {
            IIssue issueObj = null;
            //random Id values considerd
            if (issueTypeId==1)
            {
                issueObj = new Bug(issuesEngine);
            }
            else if (issueTypeId == 2)
            {
                issueObj = new Story(issuesEngine);
            }
            else if (issueTypeId == 3)
            {
                issueObj = new Tasks(issuesEngine);
            }
            
            return issueObj;          

        }
    }
}
