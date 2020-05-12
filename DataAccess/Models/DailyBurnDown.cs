using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class DailyBurnDown
    {
        public int DailyBurnDownId { get; set; }
        public int SprintId { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PointsCompleted { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PointsPending { get; set; }
    }
}
