using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WorkFlowManagement.Models
{
    public class DBManager
    {
        public static String getStatus(int s)
        {
            if (s == 1)
                return "Not Assigned";
            else if (s == 2)
                return "Pending";
            else if (s == 3)
                return "Accepted";
            else if (s == 4)
                return "Rejected";
            else
                return "";
        }
        public static String[] getUserName(String login, String pass)
        {
            String q = "";
            String [] str = new String [3];
            str[0] = "";
            q = "Select Name,User_Type,User_ID from [User] where Login = '"+login+"' and Password = '"+pass+"'";
            DataTable dt = new DataTable();
            try
            {
                using (DBHelper db = new DBHelper())
                {
                    SqlDataReader dr = db.ExecuteReader(q);
                    if (dr.Read() == true)
                    {
                        str[0] = dr.GetString(0);
                        str[1] = dr.GetString(1);
                        str[2] = dr.GetInt32(2).ToString();
                    }
                }
            }
            catch (Exception e)
            { }
            return str;
        }
        public static int getFormNum(String fname)
        {
            String q = "";
            int num = 0;
            q = "Select ID from Form where Name = '"+fname+"'";
            DataTable dt = new DataTable();
            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                if (dr.Read() == true)
                {
                    num = dr.GetInt32(0);
                }
            }
            return num;
        }
        public static int getApplicantID(String name)
        {
            String q = "";
            int num = 0;
            q = "Select User_ID from [User] where Name = '"+name+"'";
            DataTable dt = new DataTable();
            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                if (dr.Read() == true)
                {
                    num = dr.GetInt32(0);
                }
            }
            return num;
        }
        public static int getFormNumFromApp(int id)
        {
            String q = "";
            int num = 0;
            q = "Select Form_ID from Application where App_ID = "+id;
            DataTable dt = new DataTable();
            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                if (dr.Read() == true)
                {
                    num = dr.GetInt32(0);
                }
            }
            return num;
        }
        public static int getAppID(Application dto)
        {
            String q = "";
            int num = 0;
            q = "Select App_ID from Application where Form_ID = " + dto.Form_ID + " and CreatedBy = " + dto.CreatedBY + " and CreatedOn = '" + dto.CreatedOn + "' and Status = " + dto.Status;
            DataTable dt = new DataTable();
            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                if (dr.Read() == true)
                {
                    num = dr.GetInt32(0);
                }
            }
            return num;
        }
        public static String getUserName(int id)
        {
            String q = "";
            String name = "";
            q = "Select Name from [User] where User_ID = "+id;
            DataTable dt = new DataTable();
            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                if (dr.Read() == true)
                {
                    name = dr.GetString(0);
                }
            }
            return name;
        }
        public static List<Form_Approver> getApproverEntries(int id)
        {
            String q = "";
            List<Form_Approver> str = new List<Form_Approver>();
            q = "Select Approver_ID,ApprovalOrder from Form_Approver where Form_ID = "+id;
            DataTable dt = new DataTable();
            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                Form_Approver obj;
                while (dr.Read() == true)
                {
                    obj = new Form_Approver();
                    obj.Approver_ID = dr.GetInt32(0);
                    obj.ApprovalOrder = dr.GetInt32(1);
                    str.Add(obj);
                }
            }
            return str;
        }
        
        public static List<String> getForms()
        {
            String q = "";
            List<String> str = new List<string>();
            q = "Select Name from Form";
            DataTable dt = new DataTable();
            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                while (dr.Read() == true)
                {
                    str.Add(dr.GetString(0));
                }
            }
            return str;
        }
        public static String getFormName(int id)
        {
            String q = "";
            String str = "";
            q = "Select Name from Form where ID = "+id;
            DataTable dt = new DataTable();
            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                while (dr.Read() == true)
                {
                    str = dr.GetString(0);
                }
            }
            return str;
        }
        public static int getApplicationStatus(int id)
        {
            String q = "";
            int str = 0;
            q = "Select Status from Application where App_ID = " + id;
            DataTable dt = new DataTable();
            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                while (dr.Read() == true)
                {
                    str = dr.GetInt32(0);
                }
            }
            return str;
        }
        public static void setApplicationStatus(int id,int status)
        {
            String q = "";
            q = "Update Application Set Status = "+status+" where App_ID = " + id;
            using (DBHelper db = new DBHelper())
            {
                db.ExecuteQuery(q);
            }
        }
        public static void deleteApplication(int id)
        {
            String q = "";
            q = "Delete from Application where App_ID = "+id;
            using (DBHelper db = new DBHelper())
            {
                db.ExecuteQuery(q);
            }
        }
        public static void SaveApplication(Application dto)
        {
            String q = "";
            if (dto.App_ID > 0)
            {
                q = "Update Application set Form_ID = " + dto.Form_ID + ", CreatedBy = " + dto.CreatedBY + ", CreatedOn = '" + dto.CreatedOn + "', Status = " + dto.Status + " where App_ID = " + dto.App_ID;
            }
            else
            {
                q = String.Format("Insert into Application (Form_ID,CreatedBy,CreatedOn,Status) values(" + dto.Form_ID + "," + dto.CreatedBY + ",'" + dto.CreatedOn + "'," + dto.Status + ")");
            }
            using (DBHelper db = new DBHelper())
            {
                db.ExecuteQuery(q);
            }
        }
        public static void SaveRequest(Request dto)
        {
            String q = "";
            q = String.Format("Insert into Request (ID,RequestBy,RName,RCNIC,RRoll_No,RSemester,REmail,RAddress) values(" + dto.ID + "," + dto.RequestBy + ",'" + dto.RName + "','" +dto.RCNIC+ "','"+dto.RRoll_No+"','"+dto.RSemester+"','"+dto.REmail+"','" + dto.RAddress + "')");
            using (DBHelper db = new DBHelper())
            {
                db.ExecuteQuery(q);
            }
        }
        public static void startWorkFlow(int app_id)
        {
            String q = "";
            int fid = getFormNumFromApp(app_id);
            List<Form_Approver> str = getApproverEntries(fid);
            WorkFlow dto = new WorkFlow();
            using (DBHelper db = new DBHelper())
            {
                foreach (var a in str)
                {
                    dto = new WorkFlow();
                    dto.App_ID = app_id;
                    dto.Approver_ID = a.Approver_ID;
                    dto.ApprovalOrder = a.ApprovalOrder;
                    if (dto.ApprovalOrder == 1)
                        dto.Status = 2;
                    else
                        dto.Status = 1;
                    q = String.Format("Insert into WorkFlow (App_ID,Approver_ID,Status,ApprovalOrder) values(" + dto.App_ID + "," + dto.Approver_ID + "," + dto.Status + "," + dto.ApprovalOrder + ")");

                    db.ExecuteQuery(q);
                }
            }
        }
        public static int getAssignmentStatus(int appID,int uID)
        {
            int s = 0;
            String q = "Select Status from WorkFlow where App_ID = "+appID+" and Approver_ID = "+uID;
            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                if (dr.Read() == true)
                {
                    s = dr.GetInt32(0);
                }
            }
            return s;
        }
        public static List<Application> getWorkFlowApplications(int UID)
        {
            
            String q = "";
            List<Application> str = new List<Application>();
            q = "Select App_ID,Form_ID,Status from Application";
            DataTable dt = new DataTable();
            
            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                Application obj;
                while (dr.Read() == true)
                {
                    obj = new Application();
                    obj.App_ID = dr.GetInt32(0);
                    obj.CreatedOn = getFormName(getFormNumFromApp(obj.App_ID));
                    obj.Status = dr.GetInt32(2);
                    obj.CreatedBY = getAssignmentStatus(obj.App_ID,UID);
                    str.Add(obj);
                }
            }
            return str;
        }
        public static List<Application> getUserCreatedApplications(int UID)
        {

            String q = "";
            List<Application> str = new List<Application>();
            q = "Select App_ID,Form_ID,CreatedOn,Status from Application where CreatedBy = "+UID;
            DataTable dt = new DataTable();

            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                Application obj;
                while (dr.Read() == true)
                {
                    obj = new Application();
                    obj.App_ID = dr.GetInt32(0);
                    obj.Form_ID = dr.GetInt32(1);
                    obj.CreatedOn = dr.GetString(2);
                    obj.Status = dr.GetInt32(3);
                    str.Add(obj);
                }
            }
            return str;
        }
        public static Models.Request getRequest(int id)
        {
            String q = "";
            Models.Request obj = new Request();
            q = "Select RequestBy,RName,RCNIC,RRoll_No,RSemester,REmail,RAddress from Request where ID = " + id;
            DataTable dt = new DataTable();

            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                
                if (dr.Read() == true)
                {
                    obj.RequestBy = dr.GetInt32(0);
                    obj.RName = dr.GetString(1);
                    obj.RCNIC = dr.GetString(2);
                    obj.RRoll_No = dr.GetString(3);
                    obj.RSemester = dr.GetString(4);
                    obj.REmail = dr.GetString(5);
                    obj.RAddress = dr.GetString(6);
                }
            }
            return obj;
        }
        public static List<WorkFlow> getWorkFlowApplicationsStatus(int appID)
        {
            String q = "";
            List<WorkFlow> str = new List<WorkFlow>();
            q = "Select Approver_ID,Status,ApprovalOrder from WorkFlow where App_ID = " + appID;
            DataTable dt = new DataTable();

            using (DBHelper db = new DBHelper())
            {
                SqlDataReader dr = db.ExecuteReader(q);
                WorkFlow obj;
                while (dr.Read() == true)
                {
                    obj = new WorkFlow();
                    obj.Approver_ID = dr.GetInt32(0);
                    obj.Status = dr.GetInt32(1);
                    obj.ApprovalOrder = dr.GetInt32(2);
                    str.Add(obj);
                }
            }
            return str;
        }
        public static void markStatus1(int appID, int uID, int status)
        {
            String q = "";
            int stat = 0,temp= 0;
            q = "select ApprovalOrder from WorkFlow where Approver_ID = "+uID+" and App_ID = "+appID;
            try
            {
                using (DBHelper db = new DBHelper())
                {
                    SqlDataReader dr = db.ExecuteReader(q);
                    if (dr.Read() == true)
                    {
                        stat = dr.GetInt32(0);
                        
                    }
                    dr.Close();
                }
                using (DBHelper db = new DBHelper())
                {
                    stat++;
                    q = "select Approver_ID from WorkFlow where App_ID = " + appID + " and ApprovalOrder = " + stat;
                    SqlDataReader dr = db.ExecuteReader(q);
                    if (dr.Read() == true)
                    {
                        temp = dr.GetInt32(0);
                    }
                    
                }
                using (DBHelper db = new DBHelper())
                {
                    if (temp > 0)
                    {
                        q = "Update WorkFlow set Status = " + 2 + " where App_ID = " + appID + " and ApprovalOrder = " + stat;
                        db.ExecuteQuery(q);
                    }
                    else
                        setApplicationStatus(appID, status);
                }
            }
            catch (Exception e)
            { }
        }
        public static void markStatus(int appID,int uID, int status)
        {
            String q = "";
            List<WorkFlow> str = new List<WorkFlow>();
            q = "Update WorkFlow Set Status = "+status+" where App_ID = " + appID+" and Approver_ID = "+uID;
            try
            {
                using (DBHelper db = new DBHelper())
                {
                    db.ExecuteQuery(q);
                    if (status == 4)
                        setApplicationStatus(appID, status);
                    else if (status == 3)
                        markStatus1(appID, uID, status);
                }
            }
            catch (Exception e)
            { }
        }
    }
}