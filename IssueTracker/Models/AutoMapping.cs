using AutoMapper;
using ServiceModel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            //CreateMap<Issue, CreateIssueRequest>();

            CreateMap<CreateIssueRequest, Issue>();
            CreateMap<Issue, CreateIssueRequest>();

            CreateMap<Status, CreateStatusRequest>();
            CreateMap<CreateStatusRequest, Status>();

            CreateMap<CreateIssueRequest, Issue>().ForMember(x => x.Status, opt => opt.Ignore());
        }
    }
}
