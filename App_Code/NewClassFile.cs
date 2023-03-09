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
/// Summary description for NewClassFile
/// </summary>
public class NewClassFile
{
    //static OleDbConnection ocon = new OleDbConnection(NDS.con());
    
    private static USEPMS.DbFunction objdbfun;
    private static bool Result;
    private static DataTable dt;     
    private static string sql;

    public NewClassFile()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public  static DataTable IS_Valied_Login(string UserName, string Password)
    {
        // Code for  valid user name and password 
        string sql = "select LOGIN_ID,USER_NAME,EMP_DEPT,EMP_CODE,USER_LEVEL,PASSWORD";
        sql = sql + " from  PMS_USER_MST ";
        sql = sql + " where upper(LOGIN_ID)='" + UserName.ToUpper()+ "'";
        sql = sql + " and ACTIVE_FLAG = 'Y' ";
        sql = sql + " and  PASSWORD=ENCRYPT('"+Password+"')";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable IS_SpLogin(string UserName, string spPassword)
    {
        // Code for  valid user name and password 
        string sql = "select LOGIN_ID,SP_PASSWORD";
        sql = sql + " from  PMS_USER_MST ";
        sql = sql + " where upper(LOGIN_ID)='"+UserName.ToUpper()+"'";
        sql = sql + " and ACTIVE_FLAG = 'Y' ";
        sql = sql + " and  SP_PASSWORD=ENCRYPT('" + spPassword + "')";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_UserName(string loginID)
    {
        // Code for  valid user name and password 
        string sql = "select LOGIN_ID, USER_NAME,EMP_CODE,EMP_DEPT,EMP_DESIG,USER_LEVEL,EMAIL_ADD";
        sql = sql + " from  PMS_USER_MST ";
        sql = sql + " where LOGIN_ID='"+loginID+"'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_EmpUserCode(string empcode)
    {
        // Code for  valid user name and password 
        string sql = "select LOGIN_ID,USER_NAME,EMP_CODE,EMP_DEPT,EMP_DESIG,USER_LEVEL,EMAIL_ADD";
        sql = sql + " from  PMS_USER_MST ";
        sql = sql + " where EMP_CODE='"+empcode+"'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }

    public static DataTable Is_EmpName(string empcode)
    {
        // Code For Select valid Employee Code and Employee Name 
        string sql = "SELECT EMPCODE,NAME,CLASS ";
        sql = sql + " from PMS_EMP_MST ";
        sql = sql + " where EMPCODE='"+empcode+"'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;        
    }

    public static DataTable Is_EName(string empname)
    {
        // Code for valid Employee Name 
        string sql = "SELECT  NAME ";
        sql = sql + " from  PMS_EMP_MST ";
        sql = sql + " where NAME='"+empname+ "'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_RatingScale(string empcode, string appmonth)
    {
        // Code for  valid Rating Scale 
        string sql = "SELECT  RATING, DEFINISTION, ATTRIBUTE_SCORE, AGGRAGATE_SCORE_RANGE, P_YEAR,TO_CHAR(FROM_DT,'DD-Mon-yyyy') as FROM_DT,TO_CHAR(TO_DT,'DD-Mon-yyyy') as TO_DT,RECOMMENDATION, REVIEWER_COMMENTS,REP_REMARKS,REVIEWER_REMARKS,REVIEWER_RATING,REVIEWER_DEFINISTION,REVIEWER_ATTRIBUTE_SCORE, REVIEWER_AGG_SCORE_RANGE, RATING_SCALE_L3, DEFINITION_L3, ATTRI_SCORE_L3, AGGRAT_L3";
        sql = sql + " from  PMS_RATING_SCALE ";
        sql = sql + " where EMP_CODE='" + empcode + "' and APP_MONTH='"+appmonth+"'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_RatingAttribute(string empcode,string appmonth)
    {
        // Code for  valid Rating Attribute 
        string sql = "SELECT rownum,ATTRIBUTES,RATING,RATING_BY,RATING_BY_L2_LEVEL,decode(RATING_L2,null,'-SELECT-',RATING_L2) RATING_L2";
        sql = sql + " from  PMS_EMP_RATING ";
        sql = sql + " where EMP_CODE='" + empcode + "' and APP_MONTH='" + appmonth.ToString() + "'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_RatingL1Attribute(string empcode, string appmonth)
    {
        // Code for  valid Rating Attribute 
        string sql = "SELECT rownum,ATTRIBUTES AS TEMP_DESC,decode(RATING,null,'-SELECT-',RATING) RATING ,RATING_BY,RATING_BY_L2_LEVEL,decode(RATING_L2,null,'-SELECT-',RATING_L2) RATING_L2";
        sql = sql + " from  PMS_EMP_RATING ";
        sql = sql + " where EMP_CODE='" + empcode + "' and APP_MONTH='" + appmonth.ToString() + "'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_PeriodMst(string empcode)
    {
        // Code for  valid Rating Attribute 
        string sql = "SELECT DISTINCT P_YEAR,TO_CHAR(FROM_DT,'DD-Mon-yyyy') AS FROM_DT,TO_CHAR(TO_DT,'DD-Mon-yyyy') AS TO_DT ";
        sql = sql + " FROM PMS_PERIOD_MST A,PMS_DATA B ";
        sql = sql + " WHERE  A.PERIOD_ID=B.APP_MONTH AND B.EMPCODE='"+empcode+"'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_RatingByL1(string empcode)
    {
        // Code for  valid  Rating By L1 and L2
        string sql = "SELECT rownum,ATTRIBUTES,RATING,RATING_BY,RATING_BY_L2_LEVEL,RATING_L2,RATING_BY_L3,RATING_L3 ";
        sql = sql + " from  PMS_EMP_RATING ";
        sql = sql + " where EMP_CODE='" + empcode + "'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }

    public static DataTable Is_RatingByATL1(string empcode)
    {
        // Code for  valid  Rating By L1 and L2
        string sql = "SELECT RATING_BY_L1 ";
        sql = sql + " from  PMS_RATING_SCALE ";
        sql = sql + " where EMP_CODE='" + empcode + "'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_RatingRemarks(string empcode)
    {
        // Code for  valid Rating Remarks
        string sql = "SELECT REP_REMARKS ";
        sql = sql + " from  PMS_RATING_SCALE ";
        sql = sql + " where EMP_CODE='" + empcode + "'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_Empdesc(string clcat)
    {
        // Code for  valid  master date for Description 
        string sql = "SELECT  initcap(TEMP_DESC) as temp_desc,'-SELECT-'as RATING";
        sql = sql + " from  PMS_TEMPLATE_MST where CATEGORY='"+clcat+"'and STATUS='Y'";
      //  sql = sql + " where TEMP_DEPT='"+empDept+"' and TEMP_LVL='"+ empdesig +"'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }

    public static DataTable Is_dept()
    {
        // Code for  valid Department Name
        string sql = "SELECT '-SELECT-' AS DEPARTMENT from  PMS_DATA union SELECT  distinct DEPARTMENT";
        sql = sql + " from  PMS_DATA ";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_TotCalL1(string empcodeL1)
    {
        // Code for Total  Employee 
        string sql = "SELECT count(*) as tot";
        sql = sql + " from PMS_MATRIX_MST A,PMS_DATA B  WHERE  A.EMPCODE=B.EMPCODE AND A.L1EMPNO IN(SELECT  EMP_CODE FROM  PMS_USER_MST WHERE  EMP_CODE='" + empcodeL1 + "')";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_TotCalL3(string empcodeL3)
    {
        // Code for Total  Employee 
        string sql = "SELECT count(*) as tot";
        sql = sql + " from  PMS_MATRIX_MST WHERE L3EMPNO IN(SELECT  EMP_CODE FROM  PMS_USER_MST WHERE  EMP_CODE='" + empcodeL3 + "')";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }

    public static DataTable Is_TotCalL2(string empcodeL2)
    {
        // Code for Total  Employee 
        string sql = "SELECT count(*) as totL2";
        sql = sql + " from  PMS_MATRIX_MST A,PMS_DATA B where A.EMPCODE=B.EMPCODE AND  B.flag in('Y','L2Y') and A.L2EMPNO IN(SELECT  EMP_CODE FROM  PMS_USER_MST WHERE  EMP_CODE='" + empcodeL2 + "')";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_TotPendL1(string usernameL1)
    {
        // Code for Total Pending At L1 Level  
        string sql = "SELECT count(*) as totL1";
        sql = sql + " from PMS_MATRIX_MST A,PMS_DATA B WHERE  A.EMPCODE=B.EMPCODE AND B.FLAG='N' AND A.L1EMPNO IN(SELECT EMP_CODE FROM  PMS_USER_MST WHERE  EMP_CODE='"+usernameL1+"')";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }

    public static DataTable Is_TotPendLAtl3(string usernameL3)
    {
        // Code for Total Pending At L1 Level  
        string sql = "SELECT count(*) as totL1";
        sql = sql + " from  PMS_MATRIX_MST A,PMS_DATA B WHERE A.EMPCODE=B.EMPCODE AND B.FLAG='N' AND A.L3EMPNO IN(SELECT EMP_CODE FROM  PMS_USER_MST WHERE  EMP_CODE='" + usernameL3 + "')";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }

    public static DataTable Is_TotSummit(string usernameL1NotSummit)
    {
        // Code for Total Pending At L1 Level  
        string sql = "SELECT count(*) as totLY";
        sql = sql + " from  PMS_MATRIX_MST A,PMS_DATA B WHERE A.EMPCODE=B.EMPCODE AND FLAG in('Y','L2Y','L3Y') and A.L1EMPNO IN(SELECT  EMP_CODE FROM  PMS_USER_MST WHERE  EMP_CODE='" + usernameL1NotSummit + "')";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_TotPendL2(string userSumL2)
    {
        // Code for Total Pending At L2 Level   
        string sql = "SELECT count(*) as totl2";
        sql = sql + " from PMS_MATRIX_MST A,PMS_DATA B WHERE A.EMPCODE=B.EMPCODE AND  B.FLAG='L2Y' and A.L2EMPNO IN(SELECT  EMP_CODE FROM  PMS_USER_MST WHERE  EMP_CODE='" + userSumL2 + "')";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_TotPendAtL2(string userSumL3)
    {
        // Code for Total Pending At L2 Level   
        string sql = "SELECT count(*) as totl2";
        sql = sql + " from  PMS_MATRIX_MST A,PMS_DATA B  WHERE A.EMPCODE=B.EMPCODE AND B.FLAG='Y' and A.L3EMPNO IN(SELECT  EMP_CODE FROM  PMS_USER_MST WHERE  EMP_CODE='" + userSumL3 + "')";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_TotPendL3(string userSumAtL3)
    {
        // Code for Total Pending At L2 Level   
        string sql = "SELECT count(*) as totl3";
        sql = sql + " from  PMS_MATRIX_MST A,PMS_DATA B WHERE A.EMPCODE=B.EMPCODE AND B.FLAG='L2Y'and A.L3EMPNO IN(SELECT  EMP_CODE FROM  PMS_USER_MST WHERE  EMP_CODE='" + userSumAtL3 + "')";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }

    public static DataTable Is_TotPendATL12(string userSumAtL2)
    {
        // Code for Total Pending At L2 Level   
        string sql = "SELECT count(*) as totl3";
        sql = sql + " from PMS_MATRIX_MST A,PMS_DATA B WHERE A.EMPCODE=B.EMPCODE AND B.FLAG='Y' and A.L2EMPNO IN(SELECT  EMP_CODE FROM  PMS_USER_MST WHERE  EMP_CODE='" + userSumAtL2 + "')";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_EmpNamedept(string empdept)
    {
        // Code for  valid Employee Name 
        string sql = "SELECT '-SELECT-' AS NAME,'-SELECT-' AS L3EMPNAME from  PMS_DATA union SELECT  distinct NAME,L3EMPNAME";
        sql = sql + " from  PMS_DATA where DEPARTMENT='" + empdept + "'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
    public static DataTable Is_Reporting(string empReporting)
    {
        // Code for  valid Reporting Officer 
        string sql = "select L3EMPNAME ";
        sql = sql + " from  PMS_DATA where name='"+empReporting.ToString()+"'";
        dt = new DataTable();
        objdbfun = new USEPMS.DbFunction();
        dt = objdbfun.dmlgetquery(sql);
        return dt;
    }
}
