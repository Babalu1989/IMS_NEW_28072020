using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Summary description for NewInsertClassFile
/// </summary>
public class NewInsertClassFile
{

    private static USEPMS.DbFunction objdbfun;
    private static string sql;
    private static bool Result;  
    public NewInsertClassFile()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool UserCreation_InsertDetails(string userid, string LoginID, string username, string empcode,string empdpt,string designation, string password,string userlevel,string createUser,string userEmailID)
    {
        try
        {
            sql = "Insert into PMS_USER_MST(USER_ID,LOGIN_ID,USER_NAME,EMP_CODE,EMP_DEPT,EMP_DESIG,PASSWORD,USER_LEVEL,CREATED_BY,EMAIL_ADD)values ";
            sql = sql + "('" + userid + "','"+LoginID.ToUpper()+"','"+username.ToString().ToUpper()+"', '" + empcode.ToString().ToUpper().Trim() + "','" + empdpt.ToString().ToUpper().Trim() + "','" + designation.ToString().ToUpper().Trim() + "',ENCRYPT('"+password+"'),";
            if (userlevel.ToString()=="-SELECT-")
            {
               sql = sql + "'',";
            }
            else
            {
                sql = sql + "'" + userlevel.ToString().ToUpper().Trim() + "',";
            }
            sql = sql + " '" + createUser.ToString().Trim() + "','" + userEmailID.ToString() + "')";
            objdbfun = new USEPMS.DbFunction();
            Result = objdbfun.dmlsinglequery(sql);
            objdbfun.dbcommittrans();
            return Result;
        }
        catch (Exception ex)
        {
            objdbfun.dbrollback();
            return false;
        }
    }

    public static bool InsertBySQL(string _sSql)
    {
        return (objdbfun.dmlsinglequery(_sSql));
    }
}
