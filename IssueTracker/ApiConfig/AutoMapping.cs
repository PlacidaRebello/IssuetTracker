using AutoMapper;
using DataAccess.DataModels;
using ServiceModel.Models;
using ServiceModel.Dto;

namespace IssueTracker.ApiConfig
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateIssueRequest, Issue>(MemberList.Source)
                .ForMember(x => x.IssueStatus, opt => opt.Ignore())
                .ForMember(x => x.UserId, opt => opt.MapFrom(p => p.AssignedTo))
                .ForPath(x => x.IssueDetails.UserId, opt => opt.MapFrom(p => p.Reporter))
                .ForPath(x => x.IssueDetails.StoryPoints, opt => opt.MapFrom(p => p.StoryPoints))
                .ForPath(x => x.IssueDetails.Attachment, opt => opt.MapFrom(s => s.Attachment))
                .ForPath(x => x.IssueDetails.Enviroment, opt => opt.MapFrom(s => s.Enviroment))
                .ForPath(x => x.IssueDetails.Browser, opt => opt.MapFrom(s => s.Browser))
                .ForPath(x => x.IssueDetails.AcceptanceCriteria, opt => opt.MapFrom(s => s.AcceptanceCriteria))
                .ForPath(x => x.IssueDetails.Epic, opt => opt.MapFrom(s => s.Epic))
                .ForPath(x => x.IssueDetails.UAT, opt => opt.MapFrom(s => s.UAT))
                .ForPath(x => x.IssueDetails.TimeTracking, opt => opt.MapFrom(s => s.TimeTracking));

            CreateMap<EditIssueRequest, Issue>(MemberList.Source)
                .ForMember(x => x.IssueStatus, opt => opt.Ignore())
                .ForMember(x => x.UserId, opt => opt.MapFrom(p => p.AssignedTo))
                .ForPath(x => x.IssueDetails.UserId, opt => opt.MapFrom(p => p.Reporter))
                .ForPath(x => x.IssueDetails.StoryPoints, opt => opt.MapFrom(p => p.StoryPoints))
                .ForPath(x => x.IssueDetails.Attachment, opt => opt.MapFrom(s => s.Attachment))
                .ForPath(x => x.IssueDetails.Enviroment, opt => opt.MapFrom(s => s.Enviroment))
                .ForPath(x => x.IssueDetails.Browser, opt => opt.MapFrom(s => s.Browser))
                .ForPath(x => x.IssueDetails.AcceptanceCriteria, opt => opt.MapFrom(s => s.AcceptanceCriteria))
                .ForPath(x => x.IssueDetails.Epic, opt => opt.MapFrom(s => s.Epic))
                .ForPath(x => x.IssueDetails.UAT, opt => opt.MapFrom(s => s.UAT))
                .ForPath(x => x.IssueDetails.TimeTracking, opt => opt.MapFrom(s => s.TimeTracking));

            CreateMap<Issue, GetIssueData>()
                .ForMember(dest => dest.AssignedTo, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.IssueDetailsId, opt => opt.MapFrom(src => src.IssueDetails.IssueDetailsId))
                .ForMember(dest => dest.Attachment, opt => opt.MapFrom(src => src.IssueDetails.Attachment))
                .ForMember(dest => dest.AcceptanceCriteria, x => x.MapFrom(src => src.IssueDetails.AcceptanceCriteria))
                .ForMember(dest => dest.Browser, x => x.MapFrom(src => src.IssueDetails.Browser))
                .ForMember(dest => dest.Enviroment, x => x.MapFrom(src => src.IssueDetails.Enviroment))
                .ForMember(dest => dest.Epic, x => x.MapFrom(src => src.IssueDetails.Epic))
                .ForMember(dest => dest.UAT, x => x.MapFrom(src => src.IssueDetails.UAT))
                .ForMember(dest => dest.StoryPoints, x => x.MapFrom(src => src.IssueDetails.StoryPoints))
                .ForMember(dest => dest.TimeTracking, x => x.MapFrom(src => src.IssueDetails.TimeTracking))
                .ForMember(dest => dest.Reporter, x => x.MapFrom(src => src.IssueDetails.UserId));

            CreateMap<CreateIssueStatusRequest, IssueStatus>(MemberList.Source);
            CreateMap<EditIssueStatusRequest, IssueStatus>(MemberList.Source);
            CreateMap<IssueStatus, GetIssueStatusData>();

            CreateMap<CreateIssueTypeRequest, ServiceModel.Models.IssueType>(MemberList.Source);
            CreateMap<EditIssueTypeRequest, ServiceModel.Models.IssueType>(MemberList.Source);
            CreateMap<ServiceModel.Models.IssueType, GetIssueTypeData>();

            CreateMap<IssuesCountByType, GetIssueCountByType>();
            CreateMap<DailyBurnDown, GetDailyBurnDownData>();

            CreateMap<RegisterUserRequest, AppUser>(MemberList.Source)
                .ForSourceMember(x => x.Password, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.ConfirmPassword, cp => cp.DoNotValidate());

            CreateMap<CreateSprintRequest, Sprint>(MemberList.Source);
            CreateMap<EditSprintRequest, Sprint>(MemberList.Source);
            CreateMap<Sprint, GetSprintData>();
            CreateMap<Sprint, GetSprintsList>();

            CreateMap<SprintStatus, GetSprintStatusData>();

            CreateMap<CreateReleaseRequest, Release>(MemberList.Source);
            CreateMap<EditReleaseRequest, Release>(MemberList.Source);
            CreateMap<Release, GetReleaseData>();
            CreateMap<Release, GetReleaseList>();
        }
    }
}
