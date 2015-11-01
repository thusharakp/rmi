using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class Admin_editordetails : System.Web.UI.Page
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
            filldd();
        }

    }
    private void filldd()
    {
        SqlConnection con = new SqlConnection(c1.ConnectionString());
        con.Open();
        string cmd = @"select Id,Domain from Domain";
        SqlDataAdapter adp = new SqlDataAdapter(cmd, con);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        ddlDomain.DataSource = dt;
        ddlDomain.DataTextField = "Domain";
        ddlDomain.DataValueField = "Id";
        ddlDomain.DataBind();
        ddlDomain.Items.Insert(0, new ListItem("--Select Domain--", "0"));
    }

    private void GridReresh()
    {
        SqlConnection con = new SqlConnection(c1.ConnectionString());
        //con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|webdb.mdf;Integrated Security=True;User Instance=True";
        con.Open();
        SqlDataAdapter Ar = new SqlDataAdapter(@"select id,wdb,contactnum,emailid,url,status from registernew where domain='" + ddlDomain.SelectedValue + "'", con);
        DataTable dt = new DataTable();
        Ar.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection con = new SqlConnection(c1.ConnectionString());

        con.Open();
        Label lbid = GridView1.Rows[e.RowIndex].FindControl("lblID") as Label;
        Label wdb = GridView1.Rows[e.RowIndex].FindControl("lbledit") as Label;
        string qry = "select status from registernew where id='" + lbid.Text + "'";
        SqlCommand cmd1 = new SqlCommand(qry, con);
        SqlDataReader dr = cmd1.ExecuteReader();
        string st = "";
        while (dr.Read())
        {
            st = dr["status"].ToString();
        }
        if (st == "ACTIVATED")
        {
            Response.Write("<script>alert('Already Activated')</script>");

            return;
        }

        qry = "update registernew set status='ACTIVATED' where id='" + lbid.Text + "'";

        int Dom_id = Convert.ToInt32(ddlDomain.SelectedValue);
        Directory.CreateDirectory(Server.MapPath("~/TrainData/" + Dom_id + "/" + wdb.Text));
        c1.ExecuteNonQuery(qry);
        con.Close();
        GridReresh();

    }
    protected void ddlDomain_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridReresh();
    }
}