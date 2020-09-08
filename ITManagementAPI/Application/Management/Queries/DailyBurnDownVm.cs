using DataAccess.Models;
using ITManagementAPI.Application.Automapper;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITManagementAPI.Application.Management.Queries
{
    public class DailyBurnDownVm:IMapFrom<DailyBurnDown>
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
