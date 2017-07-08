using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkFlowManagement.Models
{
    public class User
    {
        public int User_ID { get; set;}
        public String Login { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Designation { get; set; }
        public String Email { get; set; }
        public String User_Type { get; set; }
        public Boolean IsActive { get; set; }
    }
}