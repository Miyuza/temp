//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkFlowManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkFlow
    {
        public int ID { get; set; }
        public int App_ID { get; set; }
        public int Approver_ID { get; set; }
        public int Status { get; set; }
        public int ApprovalOrder { get; set; }
    
        public virtual User User { get; set; }
    }
}
