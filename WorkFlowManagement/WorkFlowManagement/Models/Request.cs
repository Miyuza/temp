using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkFlowManagement.Models
{
    public class Request
    {
        public int ID { get; set; }
        public int RequestBy { get; set; }
        public String RName { get; set; }
        public String RCNIC { get; set; }
        public String RRoll_No { get; set; }
        public String RSemester { get; set; }
        public String REmail { get; set; }
        public String RAddress { get; set; }
    }
}