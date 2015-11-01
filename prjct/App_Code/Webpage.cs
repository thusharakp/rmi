using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Webpage
/// </summary>
public class Webpage
{
	public Webpage()
	{
        List<Result> listresult = new List<Result>();
		//
		// TODO: Add constructor logic here
		//
	}
    public List<Result> listresult { get; set; }
    public void add(Result r)
    {
        listresult.Add(r);   
    }
}