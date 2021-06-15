using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

namespace Electorate
{
    public partial class SiteMaster : MasterPage
    {
        public static string UserPhoto = "";
        public static string User = "";
        public static string UserLvl = "";
        public static string sFullName = "";
        public static string sActive = "";
        public static string sTreeview = "";
        public static string sTreeviewSub = "";
        public static string sTreeviewSub2 = "";
        public static string sTreeviewSub3 = "";
        public static string sActive2 = "";
        public static string sTreeview2 = "";
        public static string sTreeview3 = "";
        public static string sTreeview4 = "";
        public static string sTreeview2Sub = "";
        public static string sTreeview2Sub2 = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            // this.CheckSessionTimeout();

            if (Session["sUserID"] == null)
            {
                Session.Remove("sUserID");
                Session.Remove("sName");
                Session.Remove("UserLevel");
                Session.Remove("sProfilePath");

                Session.Clear();
                // Response.Redirect("/Login");
            }
            else
            {
                User = Session["sUserID"].ToString();
                //sFullName = Session["sName"].ToString();
                lblFullName.Text = Session["sName"].ToString();

                if (Session["sProfilePath"].ToString() != "")
                {
                    UserPhoto = "../" + Session["sProfilePath"].ToString();
                    Image1.ImageUrl = @"~/" + Session["sProfilePath"].ToString();
                }
                else
                {
                    UserPhoto = "../dist/img/user2-160x160.jpg";
                    Image1.ImageUrl = @"~/dist/img/user2-160x160.jpg";

                }

                if (Session["sArena"] != null)
                {
                    lblArena.Text = (String)Session["sArena"];

                    if (lblArena.Text == "AMENIC N CALAJOAN")
                    {
                        imgArenaLogo.ImageUrl = @"~/Uploaded/Logo/Amenic_nobackground.png";
                    }
                    else
                    {
                        imgArenaLogo.ImageUrl = @"~/Uploaded/Logo/D_Logo.jpg";
                    }

                }

            }

        }


        protected string SetCssClass(string page)
        {
            string sPage = Request.Url.AbsolutePath.ToLower().ToString();

            if (sPage == "/arena" || sPage == "/usermanagement" || sPage == "/viewlogs" || sPage == "/cockhouse")
            {
                sTreeview = "menu-open";
                sTreeview2 = "active";
            }
            else
            {
                sTreeview = "";
                sTreeview2 = "";
            }

            return Request.Url.AbsolutePath.ToLower().EndsWith(page.ToLower()) ? "active" : "";
        }
        private void CheckSessionTimeout()
        {
            string msgSession = "Warning: Within next 3 minutes, if you do not do anything," +
                       " our system will redirect to the login page. Please save changed data.";
            //time to remind, 3 minutes before session ends
            int int_MilliSecondsTimeReminder = (this.Session.Timeout * 60000) - 3 * 60000;
            //time to redirect, 5 milliseconds before session ends
            int int_MilliSecondsTimeOut = (this.Session.Timeout * 60000) - 5;

            string str_Script = @"
            var myTimeReminder, myTimeOut; 
            clearTimeout(myTimeReminder); 
            clearTimeout(myTimeOut); " +
                    "var sessionTimeReminder = " +
                int_MilliSecondsTimeReminder.ToString() + "; " +
                    "var sessionTimeout = " + int_MilliSecondsTimeOut.ToString() + ";" +
                    "function doReminder(){ alert('" + msgSession + "'); }" +
                    "function doRedirect(){ window.location.href='Login'; }" + @"
            myTimeReminder=setTimeout('doReminder()', sessionTimeReminder); 
            myTimeOut=setTimeout('doRedirect()', sessionTimeout); ";

            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(),
                  "CheckSessionOut", str_Script, true);
        }
    }
}