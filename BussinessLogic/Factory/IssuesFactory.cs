using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.DataModels;

namespace BussinessLogic.Factory
{
    public static class IssuesFactory
    {
        public static IIssue GetIssueManager(int issueTypeId, IIssuesEngine issuesEngine)
        {
            IIssue issueObj = null;
            if (issueTypeId == (int)IssueType.Bug)
            {
                issueObj = new Bug(issuesEngine);
            }
            else if (issueTypeId == (int)IssueType.Story)
            {
                issueObj = new Story(issuesEngine);
            }
            else if (issueTypeId == (int)IssueType.Task)
            {
                issueObj = new Tasks(issuesEngine);
            }

            return issueObj;
        }
    }
}
