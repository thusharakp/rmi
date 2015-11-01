using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

public partial class _Default : System.Web.UI.Page
{
    Db c1 = new Db();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnlg_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(c1.ConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@name", txtun.Text);
        cmd.Parameters.AddWithValue("@pwd", txtps.Text);
        cmd.Connection = con;
        cmd.CommandText = @"select * from login where username=@name and password=@pwd";
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Session["username"] = reader["username"].ToString();

            }

            Response.Redirect("~/Admin/Adhome.aspx");
        }
        else
        {
            reader.Close();
            SqlCommand cmdreg = new SqlCommand();
            cmdreg.Parameters.AddWithValue("@uname", txtun.Text);
            cmdreg.Parameters.AddWithValue("@pass", txtps.Text);
            cmdreg.Connection = con;
            cmdreg.CommandText = @"select id,username,password,status,url from registernew where username=@uname and password=@pass";
            SqlDataReader reader1 = cmdreg.ExecuteReader();
            string status = "";
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    Session["id"] = reader1["id"].ToString();
                    Session["username"] = reader1["username"].ToString();
                    status = reader1["status"].ToString();
                    Session["url"] = reader1["url"].ToString();

                }
                if (status == "ACTIVATED")
                {
                    Response.Redirect("~/Editor/editorhome.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Account has not been activated.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter valid Username and Password')</script>");
            }
            reader1.Close();
        }

        con.Close();
    }
}
