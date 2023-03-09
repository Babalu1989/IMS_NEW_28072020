using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
	public Class1()
	{
		//
		// TODO: Add constructor logic here
		//
	}    

    public static void ClearControls(Control control)
		{
			for (int i=control.Controls.Count -1; i>=0; i--)
			{
				ClearControls(control.Controls[i]);
			}

			if (!(control is TableCell))
			{
				if (control.GetType().GetProperty("SelectedItem") != null)
				{
					LiteralControl literal = new LiteralControl();
					control.Parent.Controls.Add(literal);
					try
					{
						literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control,null);
					}
					catch
					{
					}
					control.Parent.Controls.Remove(control);
				}
				else
					if (control.GetType().GetProperty("Text") != null)
				{
					LiteralControl literal = new LiteralControl();
					control.Parent.Controls.Add(literal);
					literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control,null);
					control.Parent.Controls.Remove(control);
				}
			}
			return;
		}

    public static void showmessagebox(string _msg)
    {
        Page page = HttpContext.Current.Handler as Page;
        page.RegisterStartupScript("key2", "<script>alert('" + _msg + "');</script>");

    }
}
