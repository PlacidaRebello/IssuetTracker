using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Dto
{
    public class DragDropIssueRequest
    {
        public bool PrevItem { get; set; }
        public int PrevItemOrder { get; set; }
        public int NextItemOrder { get; set; }
        public int CurrentItemIndex { get; set; }   
        public int CurrentItemOrder { get; set; }
        public int NoOfItems { get; set; }
        public string IssueType { get; set; }   
    }
}
