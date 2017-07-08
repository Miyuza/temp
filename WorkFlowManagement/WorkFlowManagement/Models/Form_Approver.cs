using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkFlowManagement.Models
{
    public class Form_Approver
    {
        public int ID { get; set; }
        public int Form_ID { get; set; }
        public int Approver_ID { get; set; }
        public int ApprovalOrder { get; set; }
    }
}