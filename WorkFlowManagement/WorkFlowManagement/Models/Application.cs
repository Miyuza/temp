using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkFlowManagement.Models
{
    public class Application
    {
        public int App_ID { get; set; }
        public int Form_ID { get; set; }
        public int CreatedBY { get; set; }
        public String CreatedOn { get; set;}
        public int Status { get; set; }
    }
}