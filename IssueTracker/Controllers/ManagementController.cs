using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using BussinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.Dto;

namespace IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIssuePriorityLogic _issuesPriorityLogic;
        public ManagementController(IMapper mapper, IIssuePriorityLogic issuesPriorityLogic)
        {
            _mapper = mapper;
            _issuesPriorityLogic = issuesPriorityLogic;
        }
        [HttpGet]
        public IEnumerable<GetIssueData> GetInitialIssueList()
        {
            List<Issue> issues = _issuesPriorityLogic.GetManagementIssuesList();
            List<GetIssueData> issueList = _mapper.Map<List<Issue>, List<GetIssueData>>(issues);
            return issueList;
        }

        [HttpPut]
        public SuccessResponse UpdateIssuePriority(DragDropIssueRequest dragDropIssue)
        {
            _issuesPriorityLogic.UpdateIssuePrirority(dragDropIssue.PrevItem, dragDropIssue.PrevItemId, dragDropIssue.NextItemId,
                dragDropIssue.CurrentItemIndex, dragDropIssue.IssueId);
            return new SuccessResponse
            {
                Message = "Succesfully"
            };
        }

        [HttpGet]
        [Route("GetIssuesCountByType")]
        public List<GetIssueCountByType> GetIssueCountByType() 
        {
            List<IssuesCountByType> issueCount=_issuesPriorityLogic.GetIssuesCountByTypes();
            List<GetIssueCountByType> issueList = _mapper.Map<List<IssuesCountByType>, List<GetIssueCountByType>>(issueCount);
            return issueList;
        }

        [HttpGet]
        [Route("GetBurnDownData")]
        public List<GetDailyBurnDownData> getDailyBurnDowns() 
        {
            List<DailyBurnDown> burnDown = _issuesPriorityLogic.GetDailyBurnDowns();
            List<GetDailyBurnDownData> data = _mapper.Map<List<DailyBurnDown>, List<GetDailyBurnDownData>>(burnDown);
            for (int i = 0; i < data.Count; i++)
            {
                data[i].Date = burnDown[i].Date.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
            }
            return data;
        }
    }
}