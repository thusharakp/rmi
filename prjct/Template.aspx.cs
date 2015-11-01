using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Template : System.Web.UI.Page
{
    Db d = new Db();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection(d.ConnectionString());
            con.Open();
            string cmd = @"select wdb from registernew";
            SqlDataAdapter adp = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            ddlweb.DataSource = dt;
            ddlweb.DataTextField = "wdb";
            ddlweb.DataValueField = "wdb";
            ddlweb.DataBind();
            ddlweb.Items.Insert(0, new ListItem("--Select WebDb--", "0"));

        }
        HyperLink2.Visible = true;
        HyperLink1.Visible = false;


    }
    protected void btnregt_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(d.ConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@wdb", ddlweb.SelectedValue.ToString());
        cmd.Parameters.AddWithValue("@element", txtel.Text);
        cmd.Parameters.AddWithValue("@attr", txtatr.Text);
        cmd.Parameters.AddWithValue("@value", txtval.Text);
        cmd.CommandText = @"insert into Templ_tab (wdb,element,attribute,value) values(@wdb,@element,@attr,@value)";
        cmd.Connection = con;
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            Response.Write("<script>alert('inserted successfully')</script>");
        }
        else
        {
            Response.Write("<script>alert('some problems occured')</script>");
        }
    }
}