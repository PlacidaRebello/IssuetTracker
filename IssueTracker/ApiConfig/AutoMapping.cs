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

            CreateMap<CreateIssueRequest, IssueDetails>(MemberList.Source);
            CreateMap<CreateIssueRequest, Issue>(MemberList.Source)
                .ForMember(x => x.IssueStatus, opt => opt.Ignore())
                .ForMember(x=>x.UserId,opt=>opt.MapFrom(p=>p.AssignedTo))
                .ForMember(x => x.IssueDetails, opt => opt.MapFrom(s => s));

            CreateMap<EditIssueRequest, IssueDetails>(MemberList.Source);
            CreateMap<EditIssueRequest, Issue>(MemberList.Source)
                .ForMember(x => x.IssueStatus, opt => opt.Ignore())
                .ForMember(x=>x.UserId,opt=>opt.MapFrom(p=>p.AssignedTo))
                .ForMember(x => x.IssueDetails, opt => opt.MapFrom(s => s));

            //CreateMap<IssueDetails, GetIssueData>(MemberList.Source);
            CreateMap<Issue, GetIssueData>()
                .ForMember(dest=>dest.AssignedTo,opt=>opt.MapFrom(src=>src.UserId))
                .ForMember(dest=>dest.IssueDetailsId,opt=>opt.MapFrom(src=>src.IssueDetails.IssueDetailsId))
                .ForMember(dest=>dest.Attachment,opt=>opt.MapFrom(src=>src.IssueDetails.Attachment))
                .ForMember(dest=>dest.AcceptanceCriteria,x=>x.MapFrom(src=>src.IssueDetails.AcceptanceCriteria))
                .ForMember(dest => dest.Browser, x => x.MapFrom(src => src.IssueDetails.Browser))
                .ForMember(dest => dest.Enviroment, x => x.MapFrom(src => src.IssueDetails.Enviroment))
                .ForMember(dest => dest.Epic, x => x.MapFrom(src => src.IssueDetails.Epic))
                .ForMember(dest => dest.UAT, x => x.MapFrom(src => src.IssueDetails.UAT))
                .ForMember(dest => dest.StoryPoints, x => x.MapFrom(src => src.IssueDetails.StoryPoints))
                .ForMember(dest => dest.TImeTracking, x => x.MapFrom(src => src.IssueDetails.TimeTracking))
                .ForMember(dest => dest.Reporter, x => x.MapFrom(src => src.IssueDetails.UserId));

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
