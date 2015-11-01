using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class Admin_Domain : System.Web.UI.Page
{
    Db d = new Db();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        int cnt = 0;
        SqlConnection con = new SqlConnection(d.ConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"select count(Id) as cnt from Domain";
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            cnt = Convert.ToInt32(dr["cnt"].ToString());
        }
        dr.Close();
        if (cnt < 4)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@dom", txtdom.Text);
            cmd.CommandText = @"insert into domain (Domain) output inserted.Id values(@dom)";
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            if (i > 0)
            {
                Directory.CreateDirectory(Server.MapPath("~/TrainData/" + i));
                Response.Write("<script>alert('Domain Registered Successfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('Problem with registration')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Not allowed!')</script>");
        }
    }
}