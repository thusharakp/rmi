using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Editor_Changeps : System.Web.UI.Page
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
                Response.Redirect("~/Default.aspx");
            }
        }
    }
    protected void btncp_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(m.ConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@psd", txtps.Text);
        cmd.Connection = con;
        cmd.CommandText = @"select password from login where password=@psd";

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@psd", txtcps.Text);
            cmd.Parameters.AddWithValue("@uname", Session["username"].ToString());

            cmd.CommandText = @"update login set password=@psd where username=@uname";
            dr.Close();

            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("<script>alert('Updated Successfully')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Current Pasword is Invalid')</script>");
            return;
        }

    }
    protected void btncl_Click(object sender, EventArgs e)
    {

    }
}