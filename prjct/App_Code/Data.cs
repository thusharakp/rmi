using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for Data
/// </summary>
public class Data
{
    public Data(string data, string tag)
    {
        this.data = data;
        this.tag = tag;
    }
    public string data{ get; set;}
    public string tag { get; set; }
   
}
