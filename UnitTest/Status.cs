using System.ComponentModel.DataAnnotations;

namespace ServiceModel.Type
{
    public class Status
    {
        [Required]
        public string StatusName { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
