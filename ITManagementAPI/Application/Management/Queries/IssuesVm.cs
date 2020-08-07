using AutoMapper;
using DataAccess.Models;
using ITManagementAPI.Application.Automapper;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITManagementAPI.Application.Management.Queries
{
    public class IssuesVm:IMapFrom<Issue>
    {
        public int IssueId { get; set; }
        public string StatusName { get; set; }
        public int IssueDetailsId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string Tags { get; set; }
        public int IssueStatusId { get; set; }
        public string CreatedBy { get; set; }
        public int Order { get; set; }
        public int IssueTypeId { get; set; }
        public int SprintId { get; set; }
        //details
        public string Attachment { get; set; }
        public string Reporter { get; set; }
        public string Enviroment { get; set; }
        public string Browser { get; set; }
        public string AcceptanceCriteria { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal StoryPoints { get; set; }
        public int Epic { get; set; }
        public bool UAT { get; set; }
        public string TimeTracking { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Issue, IssuesVm>()
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
        }
    }
}
