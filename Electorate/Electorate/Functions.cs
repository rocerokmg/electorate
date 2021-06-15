using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Web;
using System.Configuration;
using System.IO;
using System.Globalization;
using System.Linq;

namespace Electorate
{
    public class SQL
    {
        public static string SQL_OLS
        {            
            get { return "Data Source=CODEV-LAPTOP-00;Initial Catalog=TestDB;Trusted_Connection=True; Timeout=200"; }           
        }
        public static void SQLQuery(string strQry, string strConnection)
        {
            try
            {
                SqlConnection SC = new SqlConnection(strConnection); SC.Open();
                SqlCommand CMD = new SqlCommand(strQry, SC);
                CMD.ExecuteNonQuery();
                SC.Close();
                SC.Dispose();
            }
            catch (Exception ex) { throw ex; }

        }

        // ------------------------------------------------------------------------------------------------

        public static bool Login_CheckPW(string UserName, string PW)
        {
            bool bReturn = false;
            string sqlstr = "SELECT TOP 1 * FROM SF_Users Where UserName = '" + UserName + "'";

            try
            {
                if (UserName.Trim() != "" && PW.Trim() != "")
                {
                    SqlConnection SC = new SqlConnection(SQL.SQL_OLS); SC.Open();
                    SqlCommand CMD = new SqlCommand(sqlstr, SC);
                    SqlDataReader DR = CMD.ExecuteReader();

                    if (DR.HasRows)
                    {
                        while (DR.Read())
                        {
                            if (UserName == DR["UserName"].ToString() && PW == DR["Password"].ToString()) bReturn = true;
                        }
                    }

                    DR.Close();
                    SC.Close();
                    SC.Dispose();
                }
            }
            catch (Exception) { }
            return bReturn;
        }

        public static string LoginName(string UserName)
        {
            string sqlstr = "Select TOP 1 * FROM Users_Table Where UserName = '" + UserName + "'";
            string strReturn = "";
            try
            {
                if (UserName.Trim() != "")
                {
                    SqlConnection SC = new SqlConnection(SQL.SQL_OLS); SC.Open();
                    SqlCommand CMD = new SqlCommand(sqlstr, SC);
                    SqlDataReader DR = CMD.ExecuteReader();
                    if (DR.HasRows)
                    {
                        while (DR.Read())
                        {
                            strReturn = UserName + " | " + DR["Last_Name"].ToString() + ", " + DR["First_Name"].ToString() + " " + DR["Middle_Name"].ToString();
                        }
                    }
                    DR.Close();
                    SC.Close();
                    SC.Dispose();
                }
            }
            catch (Exception) { }
            return strReturn;
        }

        public static string LoginFullName(string UserName)
        {
            string sqlstr = "Select TOP 1 * FROM Users_Table Where UserName = '" + UserName + "'";
            string strReturn = "";
            try
            {
                if (UserName.Trim() != "")
                {
                    SqlConnection SC = new SqlConnection(SQL.SQL_OLS); SC.Open();
                    SqlCommand CMD = new SqlCommand(sqlstr, SC);
                    SqlDataReader DR = CMD.ExecuteReader();
                    if (DR.HasRows)
                    {
                        while (DR.Read())
                        {
                            strReturn = DR["First_Name"].ToString() + " " + DR["Middle_Name"].ToString() + " " + DR["Last_Name"].ToString();
                        }
                    }
                    DR.Close();
                    SC.Close();
                    SC.Dispose();
                }
            }
            catch (Exception) { }
            return strReturn;
        }

        public static DataTable GetTable(string strQry, string strCon)
        {
            DataTable DT = new DataTable();
            try
            {
                SqlConnection SC = new SqlConnection(strCon); SC.Open();
                SqlDataAdapter DA = new SqlDataAdapter(strQry, SC);
                DA.Fill(DT);
                SC.Close();
                SC.Dispose();
            }
            catch (Exception) { }
            return DT;
        }
        public static DataTable GetStoredProc(string strQry, string strCon)
        {
            DataTable DT = new DataTable();
            try
            {
                SqlConnection SC = new SqlConnection(strCon); SC.Open();
                SqlDataAdapter DA = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(strQry, SC);
                cmd.CommandType = CommandType.StoredProcedure;
                DA.SelectCommand = cmd;

                DA.Fill(DT);
                SC.Close();
                SC.Dispose();
            }
            catch (Exception) { }
            return DT;
        }

        public static void AddLogs(string strUser, string strAction, string strPC, string strIP)
        {
            string QUERY = "INSERT INTO SF_UserLogs " +
            "(UserID, Action, Log_Date, Log_PC, Log_IP) " +
            "VALUES (@UserID, @Action, @Log_Date, @Log_PC, @Log_IP)";

            SqlConnection SC = new SqlConnection(SQL_OLS); SC.Open();
            SqlCommand CMD = new SqlCommand(QUERY, SC);

            CMD.Parameters.AddWithValue("@UserID", strUser);
            CMD.Parameters.AddWithValue("@Action", strAction);
            CMD.Parameters.AddWithValue("@Log_Date", SQL.newDT());
            CMD.Parameters.AddWithValue("@Log_PC", strPC);
            CMD.Parameters.AddWithValue("@Log_IP", strIP);
            CMD.ExecuteNonQuery();

        }


        public static bool checkUser(string strUser, string strPassword)
        {
            bool res = false;


            return res;
        }

        public static string textToProper(string sName)
        {
            sName = sName.ToLower();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            sName = textInfo.ToTitleCase(sName);
            return sName;
        }

        public static string getUsername(string tID)
        {
            string sTName = "";

            DataTable DT = SQL.GetTable("SELECT * FROM SF_Users where ID = '" + tID + "'", SQL.SQL_OLS);

            if (DT.Rows.Count > 0)
            {
                sTName = DT.Rows[0]["Username"].ToString();
            }

            return sTName;
        }



        public static string getName(string tID)
        {
            string sTName = "";

            DataTable DT = SQL.GetTable("SELECT * FROM SF_Users where ID = '" + tID + "'", SQL.SQL_OLS);

            if (DT.Rows.Count > 0)
            {
                sTName = DT.Rows[0]["LastName"].ToString() + ", " + DT.Rows[0]["FirstName"].ToString() + " " + DT.Rows[0]["MiddleName"].ToString();
            }

            return sTName;
        }
        public static DateTime newDT()
        {
            DateTime utcTime = DateTime.Now.ToUniversalTime();
            DateTime newDT = System.TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time"));
            return newDT;
        }
    }
}