using AutoMapper;
using DataAccess.DataModels;
using DataAccess.Models;
using ServiceModel.Dto;

namespace IssueTracker.ApiConfig
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateIssueRequest, Issue>(MemberList.Source)
                .ForMember(x => x.IssueStatus, opt => opt.Ignore());
            CreateMap<EditIssueRequest, Issue>(MemberList.Source)
                .ForMember(x => x.IssueStatus, opt => opt.Ignore());
            CreateMap<Issue, GetIssueData>();

            CreateMap<CreateIssueStatusRequest, IssueStatus>(MemberList.Source);
            CreateMap<EditIssueStatusRequest, IssueStatus>(MemberList.Source);
            CreateMap<IssueStatus, GetIssueStatusData>();

            CreateMap<CreateIssueTypeRequest, IssueType>(MemberList.Source);
            CreateMap<EditIssueTypeRequest, IssueType>(MemberList.Source);
            CreateMap<IssueType, GetIssueTypeData>();

            CreateMap<RegisterUserRequest, AppUser>(MemberList.Source)
                .ForSourceMember(x => x.Password, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.ConfirmPassword, cp => cp.DoNotValidate());

            CreateMap<CreateSprintRequest, Sprint>(MemberList.Source);
            CreateMap<EditSprintRequest, Sprint>(MemberList.Source);
            CreateMap<Sprint, GetSprintData>();

            CreateMap<SprintStatus, GetSprintStatusData>();

            CreateMap<CreateReleaseRequest, Release>(MemberList.Source);
            CreateMap<EditReleaseRequest, Release>(MemberList.Source);
            CreateMap<Release, GetReleaseData>();
        }
    }
}
