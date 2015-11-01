using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Editor_editorhome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["id"].ToString();
        }
        catch
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}