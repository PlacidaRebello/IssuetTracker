using AutoMapper;
using DataAccess.Models;
using DataAccess.DataModels;
using ServiceModel.Dto;

namespace IssueTracker.ApiConfig
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateIssueRequest, Issue>(MemberList.Source)
                .ForMember(x => x.Status, opt => opt.Ignore());
            CreateMap<EditIssueRequest, Issue>(MemberList.Source)
                .ForMember(x => x.Status, opt => opt.Ignore());
            CreateMap<Issue, GetIssueData>();

            CreateMap<CreateStatusRequest, Status>(MemberList.Source);
            CreateMap<EditStatusRequest, Status>(MemberList.Source);
            CreateMap<Status, GetStatusData>();

            CreateMap<CreateIssueTypeRequest, IssueType>(MemberList.Source);
            CreateMap<EditIssueTypeRequest, IssueType>(MemberList.Source);
            CreateMap<IssueType, GetIssueTypeData>();

            CreateMap<RegisterUserRequest, AppUser>(MemberList.Source)
                .ForSourceMember(x => x.Password, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.ConfirmPassword, cp => cp.DoNotValidate());

            //CreateMap<CreateUserRequest, AppUser>(MemberList.Source);
        }
    }
}
