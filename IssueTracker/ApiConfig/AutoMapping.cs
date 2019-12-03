﻿using AutoMapper;
using ServiceModel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;

namespace IssueTracker.ApiConfig
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateIssueRequest, Issue>(MemberList.Source)
                .ForMember(x => x.Status, opt => opt.Ignore());
            //.ForMember(dest => dest.Status,
            //opts => opts.MapFrom(src => src.Status));            
            CreateMap<EditIssueRequest, Issue>(MemberList.Source)
                .ForMember(x => x.Status, opt => opt.Ignore());
            CreateMap<Issue, GetIssueResponse>();


            CreateMap<CreateStatusRequest, Status>(MemberList.Source);
            CreateMap<EditStatusRequest, Status>(MemberList.Source);
            CreateMap<Status, GetStatusData>();
        }
    }
}