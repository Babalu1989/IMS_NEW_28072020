using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary> 
/// Summary description for BasePage 
/// </summary> 

public class BasePage : System.Web.UI.Page
{
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        if (Session["mytheme"] == null)
        {
            Session.Add("mytheme","");
            Page.Theme = ((string)Session["mytheme"]);
        }
        else
        {
            Page.Theme = ((string)Session["mytheme"]);
        }
    }
}



