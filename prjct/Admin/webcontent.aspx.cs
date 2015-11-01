using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Threading;

public partial class Admin_webcontent : System.Web.UI.Page
{

    Db m1 = new Db();
    Logic l = new Logic();

    int c1 = 0, c2 = 0, c3 = 0, c4 = 0;
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
        Response.Redirect("~/Admin/align.aspx");


    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnview_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        //btnalg.Visible = true;
        string method = "", keygen = "", connective = "", url = "", dom = "", gkey = "";
        int id, gid, k = 0, j = 0, p = 0, r = 0, i = 0;
        SqlConnection con = new SqlConnection(m1.ConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(@"select domain,url,method,connectives from registernew where id=5", con);
       SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            i = 0;
            k = 0; j = 0; p = 0; r = 0;
            url = dr["url"].ToString();
            method = dr["method"].ToString();
            connective = dr["connectives"].ToString();
            dom = dr["domain"].ToString();
            if (dom.Equals("1"))
            {
                k++;
            }
            else if (dom.Equals("2"))
            {
                j++;
            }
            else if (dom.Equals("3"))
            {
                p++;
            }
            else
            {
                r++;
            }
            List<Thread> threads = new List<Thread>();
            //}
            //dr.Close();
            cmd = new SqlCommand(@"select top 6 id,keyword from GenKey_tab", con);
            SqlDataReader ddr = cmd.ExecuteReader();
            while (ddr.Read())
            {
                keygen = ddr["keyword"].ToString();
                gid = Convert.ToInt32(ddr["id"]);
                gkey = gid + "g";
                Thread t = new Thread(() => l.getResult(url, keygen, gkey, connective, method, Response, Server));
                threads.Add(t);
                t.Start();
                Thread.Sleep(10000);
                i++;
            }
            foreach (Thread tt in threads)
            {
                tt.Join();
            }
            gridLoad(k, j, p, r, i);

            //dr.Close();
        }
        cmd = new SqlCommand(@"select url,domain,method,connectives from registernew where id=5", con);// where url='" + selval + "'", con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            i = 0;
            k = 0; j = 0; p = 0; r = 0;
            url = dr["url"].ToString();
            method = dr["method"].ToString();
            dom = dr["domain"].ToString();
            connective = dr["connectives"].ToString();
            if (dom == "1")
            {
                k++;
            }
            else if (dom == "2")
            {
                j++;
            }
            else if (dom == "3")
            {
                p++;
            }
            else
            {
                r++;
            }
            cmd = new SqlCommand(@"select top 6 id,keyword from keyword_tab where domain='" + dom + "'", con);
            SqlDataReader ddr = cmd.ExecuteReader();
            while (ddr.Read())
            {
                string key = ddr["keyword"].ToString();
                int keyid = Convert.ToInt32(ddr["id"]);
                string dkey = keyid + "d";
                new Thread(() => l.getResult(url, key, dkey, connective, method, Response, Server)).Start();
                i++;
            }
            gridLoad(k, j, p, r, i);
            btnalg.Visible = true;
        }
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        btnalg.Visible = false;
        int f = l.deletFile();
        if (f == 0)
        {
            HttpContext.Current.Response.Write("<script>alert('No files to delete ')</script>");
        }
        else
        {
            HttpContext.Current.Response.Write("<script>alert('files deleted')</script>");
        }

    }
    protected void gridLoad(int k, int j, int p, int r, int i)
    {


        int websitesb = 0, websitese = 0, websitesj = 0, websitesm = 0, keydomb = 0, keydome = 0, keydomj = 0, keydomm = 0;
        c1 = c1 + (k * i);
        c2 = c2 + (j * i);
        c3 = c3 + (p * i);
        c4 = c4 + (r * i);
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Domain", typeof(string)), new DataColumn("WDBs", typeof(int)), new DataColumn("Keywords-General", typeof(int)), new DataColumn("Keywords-Domain Specific", typeof(int)), new DataColumn("Result Pages", typeof(int)) });
        // dt.Columns.Add("");
        SqlConnection con = new SqlConnection(m1.ConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(@"select url,domain from registernew ", con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            if (dr["domain"].ToString() == "1")
            {
                websitesb++;
            }
            else if (dr["domain"].ToString() == "2")
            {
                websitese++;
            }
            else if (dr["domain"].ToString() == "3")
            {
                websitesj++;
            }
            else
            {
                websitesm++;
            }
        }
        dr.Close();
        cmd = new SqlCommand(@"select keyword,domain from keyword_tab", con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            if (dr["domain"].ToString() == "1")
            {
                keydomb++;
            }
            else if (dr["domain"].ToString() == "2")
            {
                keydome++;
            }
            else if (dr["domain"].ToString() == "3")
            {
                keydomj++;
            }
            else
            {
                keydomm++;
            }
        }
        dr.Close();
        cmd = new SqlCommand(@"select count(keyword) from GenKey_tab", con);
        int keygenr = (Int32)cmd.ExecuteScalar();
        dt.Rows.Add("Book", websitesb, keygenr, keydomb, c1);
        dt.Rows.Add("Electronics", websitese, keygenr, keydome, c2);
        dt.Rows.Add("Job", websitesj, keygenr, keydomj, c3);
        dt.Rows.Add("Music", websitesm, keygenr, keydomm, c4);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}


