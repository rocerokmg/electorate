using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electorate.WebForms
{
    public partial class wfLogin : System.Web.UI.Page
    {
        string sIP;
        string sPC;
        protected void Page_Load(object sender, EventArgs e)
        {
            ///Response.Redirect("https://portal.jlnhs.org");
            Session.Remove("sUserID");
            Session.Remove("sUserName");
            Session.Remove("UserLevel");
            Session.Remove("sName");
            Session.Remove("sProfilePath");
            Session.Clear();
            Session.Contents.RemoveAll();

            sPC = Dns.GetHostName();

            try
            {
                sIP = HttpContext.Current.Request.UserHostAddress.ToString();
            }
            catch (Exception)
            {
                sIP = "N/A";
            }

            try
            {
                sPC = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.ToString();
            }
            catch
            {
                sPC = "N/A";
            }



        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Session.Remove("sUserID");
            Session.Remove("sName");
            Session.Remove("sUserlvl");
            Session.Remove("sProfilePath");
            Session.Remove("sArenaIDList");
            Session.Clear();

            string strUserName = txtEmail.Text.Trim();
            string strPW = txtPassword.Text.Trim();

            try
            {
                // if (strUserName != "" && strPW != "")
                DataTable DT = SQL.GetTable("SELECT TOP 1 * FROM  SF_Users Where Username = '" + strUserName + "' AND Status = 'Active'", SQL.SQL_OLS);

                if (DT.Rows.Count > 0)
                {
                    string strUserID = DT.Rows[0]["ID"].ToString();
                    string strUserLvl = DT.Rows[0]["UserLevel"].ToString();
                    string strName = DT.Rows[0]["FirstName"].ToString() + ", " + DT.Rows[0]["LastName"].ToString();
                    string sProfile = DT.Rows[0]["ProfilePic"].ToString();
             

                    if (SQL.Login_CheckPW(strUserName, strPW))
                    {
                        if (strUserLvl != "0")
                        {
                            Session["sUserID"] = strUserID;
                            Session["sName"] = strName;
                            Session["UserLevel"] = strUserLvl;
                            Session["sProfilePath"] = sProfile;
                            Session["UserName"] = txtEmail.Text;

                            SQL.AddLogs(Session["sUserID"].ToString(), "Logged in Game Cock Scheduler Online", sPC, sIP);

                            
                            Response.Redirect("/Main", true);
                        }
                        else
                        {
                            lblStatus.Text = "ACCESS DENIED. ";
                            txtEmail.Focus();
                        }
                        txtPassword.BackColor = Color.Red;
                    }
                    else
                    {
                        txtPassword.BackColor = Color.Red;

                        lblStatus.Text = "Incorrect Password.";
                        txtPassword.Focus();
                    }
                }
                else
                {
                    lblStatus.Text = "USER NOT FOUND.";
                    txtEmail.Focus();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message + " btnLogin_Click";
            }
        }
    }
}