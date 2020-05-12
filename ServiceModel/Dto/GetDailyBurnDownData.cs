using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Dto
{
    public class GetDailyBurnDownData
    {
        public int DailyBurnDownId { get; set; }
        public int SprintId { get; set; }
        public string Date { get; set; }
        public decimal PointsCompleted { get; set; }
        public decimal PointsPending { get; set; }
    }
}
