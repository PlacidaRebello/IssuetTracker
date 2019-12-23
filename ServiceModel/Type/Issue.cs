using System.ComponentModel.DataAnnotations;

namespace ServiceModel.Type
{
    public class Issue
    {
        [Required]
        public string Subject { get; set; }

        public string Description { get; set; }
        [Required]
        public string AssignedTo { get; set; }

        public string Tags { get; set; }
        [Required]
        public string Status { get; set; }
        public string CreatedBy { get; set; }
    }
}
