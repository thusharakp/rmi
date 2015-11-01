using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
//using System.Windows.Forms;
using System.IO;
using System.Data;

public partial class Editor_Register : System.Web.UI.Page
{
    Db m = new Db();
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink2.Visible = false;
        if (!IsPostBack)
        {
            SqlConnection con = new SqlConnection(m.ConnectionString());
            con.Open();
            string cmd = @"select Id,Domain from Domain";
            SqlDataAdapter adp = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Domain";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select Domain--", "0"));
        }

    }
    protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
    {

    }
    protected void btnreg_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            SqlConnection conn = new SqlConnection(m.ConnectionString());

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@url", txtur.Text);
            cmd.Connection = conn;
            cmd.CommandText = @"select url from registernew where url=@url";

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Response.Write("<script>alert('URL entered already exists')</script>");
                return;
            }
            dr.Close();
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@email", txtemail.Text);

            cmd.CommandText = @"select emailid from registernew where emailid=@email";

            SqlDataReader dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                Response.Write("<script>alert('Email entered already exists')</script>");
                return;
            }
            dr1.Close();
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@domain", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@connectives", txtcon.Text);
            cmd.Parameters.AddWithValue("@wdb", txtdb.Text);
            cmd.Parameters.AddWithValue("@contact", txtcnt.Text);
            cmd.Parameters.AddWithValue("@emailid", SqlDbType.VarChar).Value = txtemail.Text;
            cmd.Parameters.AddWithValue("@url", txtur.Text);
            cmd.Parameters.AddWithValue("@uname", txtun.Text);
            cmd.Parameters.AddWithValue("@psd", txtps.Text);
            cmd.Parameters.AddWithValue("@method", txtmeth.Text);
            cmd.Parameters.AddWithValue("@status", "ACTIVATE");
            //cmd.Connection = conn;
            cmd.CommandText = @"insert into registernew (wdb,domain,contactnum,emailid,url,username,password,method,connectives,status) values(@wdb,@domain,@contact,@emailid,@url,@uname,@psd,@method,@connectives,@status)";
            //@"insert into registernew (newspaper,editorname,contactnum,emailid,url,username,password,status) output inserted.id values('" + txtnw.Text + "','" + txted.Text + "','" + txtcnt.Text + "','" + txtemail.Text + "','" + txtur.Text + "','" + txtun.Text + "','" + txtps.Text + "','ACTIVATE')");
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                Response.Write("<script>alert('Registerd Successfully')</script>");

            }
            else
            {
                Response.Write("<script>alert('There is some problems with registration...please try again')</script>");
            }
            conn.Close();
        }
    }
    protected void btncl_Click(object sender, EventArgs e)
    {

        Response.Write("<script>alert('Are you sure to cancel?')</script>");
        ControlCollection control = Page.Controls;
        foreach (Control ct in control)
        {
            if (ct is TextBox)
            {
                ((TextBox)ct).Text = string.Empty;
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}