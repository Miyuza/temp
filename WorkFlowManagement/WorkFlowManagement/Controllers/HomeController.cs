using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkFlowManagement.Models;

namespace WorkFlowManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["Uname"] = null;
            Session["Awe"] = 0;
            return View();
        }
        public ActionResult CheckUser(String login, String pass) 
        {
            String[] str = DBManager.getUserName(login, pass);
            if (str[0] == "")
            {
                Session["Awe"] = 1;
                return View("Index");
            }
            Session["Uname"] = str[0];
            Session["UID"] = Convert.ToInt32(str[2]);
            if (str[1] == "Approver")
            {
                //var st = DBManager.getWorkFlowApplications(Convert.ToInt32(str[2]));
                return View();
            }
            else
                return View("User2");
        }
        public ActionResult Form(String formName)
        {
            ViewBag.Title = formName;
            int num = DBManager.getFormNum(formName);
            ViewBag.Fnumber = num;
            if (num == 1)
                return View("Form1");
            else if (num == 2)
                return View("Form2");
            else
                return View();
        }
        //public ActionResult FormSubmitted(String fname,String RName, String RCNIC, String RRoll_No,String RSemester, String REmail,String RAddress)
        //{
        //    int num = DBManager.getFormNum(fname);
        //    ViewBag.RName = RName;
        //    ViewBag.RCNIC = RCNIC;
        //    ViewBag.RRoll_No = RRoll_No;
        //    ViewBag.RSemester = RSemester;
           
        //    ViewBag.REmail = REmail;
        //    ViewBag.RAddress = RAddress;

        //    if (RName == "" || RCNIC == "" || RRoll_No == "" || RSemester == "" || REmail == "" || RAddress == "")
        //    {
        //        ViewBag.Fill = 1;
        //        if (num == 1)
        //            return View("Form1");
        //        else if (num == 2)
        //            return View("Form2");
        //        else
        //            return View("User2");
        //    }
        //    else
        //    {
        //        ViewBag.Fill = 0;
        //        Application obj = new Application();
        //        obj.Form_ID = num;
        //        String n = Session["Uname"].ToString();
        //        obj.CreatedBY = DBManager.getApplicantID(n);
        //        obj.CreatedOn = DateTime.Now.ToString();
        //        obj.Status = 2;
        //        DBManager.SaveApplication(obj);

        //        WorkFlow obj1 = new WorkFlow();
        //        int id = DBManager.getAppID(obj);
        //        DBManager.startWorkFlow(id);

        //        //ViewBag.Fnumber = id;
        //        Models.Request q = new Models.Request();
        //        q.ID = id;
        //        q.RequestBy = (int)Session["UID"];
        //        q.RName = RName;
        //        q.RCNIC = RCNIC;
        //        q.RRoll_No = RRoll_No;
        //        q.RSemester = RSemester;
        //        q.REmail = REmail;
        //        q.RAddress = RAddress;
        //        DBManager.SaveRequest(q);
        //        return View("User2");
        //    }
        //}
        //public ActionResult ViewForm(int id)
        //{
        //    int status = DBManager.getAssignmentStatus(id,(int)Session["UID"]);
        //    ViewBag.status = status;
        //    ViewBag.id = id;
        //    ViewBag.appStatus = DBManager.getApplicationStatus(id);
        //    int num = DBManager.getFormNumFromApp(id);
        //    ViewBag.Title = DBManager.getFormName(num);
        //    List<WorkFlow> str = DBManager.getWorkFlowApplicationsStatus(id);
        //    return View(str);
        //}
        //public ActionResult SubmitStatus(int id)
        //{
        //    ViewBag.id = 3;
        //    DBManager.markStatus(id, (int)Session["UID"], 3);
        //    return View("CheckUser");
        //}
        //public ActionResult SubmitStatus1(int id)
        //{
        //    ViewBag.id = 4;
        //    DBManager.markStatus(id, (int)Session["UID"], 4);
        //    return View("CheckUser");
        //}
        //public ActionResult Delete(int id)
        //{
        //    ViewBag.id = id;
        //    DBManager.deleteApplication(id);
        //    return View("CheckUser");
        //}
    }
}