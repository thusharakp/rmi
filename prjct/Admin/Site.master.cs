﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("~/Default.aspx");
    }
}