using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Text;
using System.Web.UI.WebControls.WebParts;

public class MessageBox
{
	public MessageBox()
	{
		
	}
    public static void show(string _msg)
    {
        System.Web.UI.Page page = HttpContext.Current.Handler as System.Web.UI.Page;
        object obj=new object();        
        page.ClientScript.RegisterStartupScript(obj.GetType(),"key2","<script>alert('" + _msg + "');</script>");
    }

    //public static bool confirm(string _msg)
    //{
        //System.Web.UI.Page page = HttpContext.Current.Handler as System.Web.UI.Page;
        //object obj = new object();
        //if (page.ClientScript.RegisterStartupScript(obj.GetType(), "key2", "<script>javascipt:return window.confirm('" + _msg + "');</script>"))
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}

    //}
}
