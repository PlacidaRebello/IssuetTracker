using BussinessLogic.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic.Factory
{
    public static class IssuesFactory
    {
        public static IIssue CreateIssue(int issueTypeId) 
        {
            IIssue issueObj = null;
            //random Id values considerd
            if (issueTypeId==1)
            {
                issueObj = new Bug();
            }
            else if (issueTypeId == 2)
            {
                issueObj = new Story();
            }
            else if (issueTypeId == 3)
            {
                issueObj = new Tasks();
            }
            
            return issueObj;          

        }
    }
}
