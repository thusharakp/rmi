using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Result
/// </summary>
public class Result
{
	public Result()
	{
        List<Data> item = new List<Data>();
		//
		// TODO: Add constructor logic here
		//
	}
    
   public List<Data> item { get; set; }
   public void add(Data data)
   {
       item.Add(data);
   }
}
