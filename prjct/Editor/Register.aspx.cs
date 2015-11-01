using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Editor_Register : System.Web.UI.Page
{
    Db c1 = new Db();
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
        SqlConnection con = new SqlConnection(c1.ConnectionString());

        con.Open();
        SqlCommand cmd = new SqlCommand();

        cmd.Parameters.AddWithValue("@id", Session["id"].ToString());
        cmd.Connection = con;
        cmd.CommandText = @"select wdb,contactnum,emailid,url,method from registernew where id=@id";

        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {

            txted.Text = dr["wdb"].ToString();
            txtcnt.Text = dr["contactnum"].ToString();
            txtemail.Text = dr["emailid"].ToString();
            txtur.Text = dr["url"].ToString();
            txtmeth.Text = dr["method"].ToString();
        }
        dr.Close();
        con.Close();

    }
    protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
    {

    }
    protected void btncl_Click(object sender, EventArgs e)
    {
        Page_Load(sender, e);
    }
    protected void btnres_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(c1.ConnectionString());

        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@wdb", txted.Text);
        cmd.Parameters.AddWithValue("@contact", txtcnt.Text);
        cmd.Parameters.AddWithValue("@emailid", txtemail.Text);
        cmd.Parameters.AddWithValue("@url", txtur.Text);
        cmd.Parameters.AddWithValue("@id", Session["id"].ToString());
        cmd.Parameters.AddWithValue("@method", txtmeth.Text);
        cmd.Connection = con;
        cmd.CommandText = @"update registernew set wdb=@wdb,contactnum=@contact,emailid=@emailid,url=@url,method=@method where id=@id";

        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('updated successfully')</script>");
        }
    }
}