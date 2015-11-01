using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Myclass
/// </summary>
public class Db
{
    public Db()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string ConnectionString()
    {
        string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        path = path + @"\webdb.mdf";
        string constring = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + path + ";Integrated Security=True;User Instance=True;MultipleActiveResultSets=true";
        return constring;

    }
    public int ExecuteNonQuery(string qry)
    {
        SqlConnection con = new SqlConnection(ConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(qry, con);
        if (cmd.ExecuteNonQuery() > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }


    }
}