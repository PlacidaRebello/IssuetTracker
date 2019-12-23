using System.ComponentModel.DataAnnotations;

namespace ServiceModel.Type
{
    public class IssueTypeType
    {
        [Required]
        public string IssueTypeName { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
