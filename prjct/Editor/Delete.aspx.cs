using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Editor_Delete : System.Web.UI.Page
{
    Db m = new Db();
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
                Response.Redirect("~/Default.apsx");
            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script>alert('All Information will be deleted')</script>");
        SqlConnection con = new SqlConnection(m.ConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(@"delete from registernew where id='" + Session["id"].ToString() + "'", con);
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('deleted parmenently')</script>");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        return;
    }
}