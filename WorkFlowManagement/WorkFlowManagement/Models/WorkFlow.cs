using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkFlowManagement.Models
{
    public class WorkFlow
    {
        public int ID { get; set; }
        public int App_ID { get; set; }
        public int Approver_ID { get; set; }
        public int Status { get; set; }
        public int ApprovalOrder { get; set; }
    }
}