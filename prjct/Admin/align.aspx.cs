using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;

public partial class Admin_align : System.Web.UI.Page
{
    Db m = new Db();
    Logic l = new Logic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                Session["username"].ToString();
            }
            catch
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        l.htmlCleaning();
    }
    
    protected void btnalign_Click(object sender, EventArgs e)
    {
       l.readFile();
    }
   
   // }
}
