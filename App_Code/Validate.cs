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
/// Summary description for Validate
/// </summary>
public class Validate
{
	public Validate()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Numberchecktxt(TextBox _txt)
    {
        _txt.Attributes.Add("onkeypress", "javascript:return numberOnly();");
        
    }
    public void currencycheck(TextBox _txt)
    {
        _txt.Attributes.Add("onkeypress", "javascript:return(currencyFormat(this,'','.',event))");
    }
    public void textlength(TextBox _txtlen)
    {
        _txtlen.MaxLength = 12;
    }
}
