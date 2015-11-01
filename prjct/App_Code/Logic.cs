using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
//using System.Windows.Forms;
using System.IO;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Logic
/// </summary>
public class Logic
{
    Db d = new Db();
    Result r = new Result();
    Webpage w = new Webpage();
    int f = 0;
    // public Logic()
    // {
    //
    // TODO: Add constructor logic here
    //
    //}
    public int getResult(string selval, string key, string keyid, string connective, string method, HttpResponse Response, HttpServerUtility Server)
    {
        //HttpContext.Current.Response.Write("check");
        string url = selval, wdb = "";
        int id = 0, count = 0;
        SqlConnection con = new SqlConnection(d.ConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(@"select domain,wdb from registernew where url='" + url + "'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            id = Convert.ToInt32(dr["domain"]);
            wdb = dr["wdb"].ToString();

        }
        string filename = key + keyid + "_Result.html";

        Response.Write(id);
        string skey = "", respser = "";
        string[] split = { " " };
        string[] keyword = key.Split(split, StringSplitOptions.RemoveEmptyEntries);
        skey = string.Join(connective, keyword);
        //HttpContext.Current.
        Response.Write(skey);
        // Response.Write(skey);
        selval = selval.Replace("...", skey);

        string path = Server.MapPath("~/TrainData/" + id + "/" + wdb + "/");
        string pathstring = System.IO.Path.Combine(path, filename);
        if (!System.IO.File.Exists(pathstring))
        {
            try
            {
                //Console.Write(selval);
                if (method.Equals("get"))
                {
                    var request = (HttpWebRequest)WebRequest.Create(selval);
                    request.Credentials = CredentialCache.DefaultCredentials;
                    ((HttpWebRequest)request).UserAgent = "Mozilla/5.0/(Windows NT 6.1)AppleWebKit/537.36(KHTML,like Gecko)Chrome/41.0.2228.0 Safari/537.36";
                    request.Method = method;
                    var response = (HttpWebResponse)request.GetResponse();
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    // txtext.Text = responseString;
                    System.IO.File.AppendAllText(pathstring, responseString + Environment.NewLine);



                }
                else if (method.Equals("post"))
                {
                    var request = (HttpWebRequest)WebRequest.Create(selval);
                    request.Method = method;
                    string postData = skey;
                    byte[] data = Encoding.ASCII.GetBytes(postData);
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    ((HttpWebRequest)request).UserAgent = "Mozilla/5.0/(Windows NT 6.1)AppleWebKit/537.36(KHTML,like Gecko)Chrome/41.0.2228.0 Safari/537.36";

                    Stream dstream = request.GetRequestStream();

                    dstream.Write(data, 0, data.Length);
                    dstream.Close();

                    WebResponse response = (HttpWebResponse)request.GetResponse();

                    dstream = response.GetResponseStream();

                    StreamReader responseString = new StreamReader(dstream, System.Text.Encoding.UTF8);
                    respser = responseString.ReadToEnd();
                    System.IO.File.AppendAllText(pathstring, respser + Environment.NewLine);
                    //count++;

                }
            }
            catch (WebException e)
            {
                string pageContent = new StreamReader(e.Response.GetResponseStream()).ReadToEnd().ToString();
                //return pageContent;
                //HttpContext.Current.Response.Write(pageContent);
                Response.Write(pageContent);
            }
        }
        else
        {

        }
        return count;
    }
    public int deletFile()
    {
        int id;
        string wdb = "";
        SqlConnection con = new SqlConnection(d.ConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(@"select Id from Domain");

        cmd = new SqlCommand(@"select domain,wdb from registernew", con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            id = Convert.ToInt32(dr["domain"]);
            wdb = dr["wdb"].ToString();

            string path = HttpContext.Current.Server.MapPath("~/TrainData/" + id + "/" + wdb + "/");
            if (Directory.GetFiles(path) != null)
            {
                foreach (string file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                    f++;
                }
            }
            else
            {
                f = 0;

            }
        }
        return f;

    }
    public void htmlCleaning()
    {
        int id;
        string wdb = "", element = "", attribute = "", value = "";

      
        SqlConnection con = new SqlConnection(d.ConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(@"select top 1 domain,wdb from registernew", con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            id = Convert.ToInt32(dr["domain"]);
            wdb = dr["wdb"].ToString();
            string path1 = HttpContext.Current.Server.MapPath("~/TrainData/" + id + "/" + wdb + "/");
            string path = HttpContext.Current.Server.MapPath("~/TrainData/" + id + "/" + wdb + "/" + "sanitized");
            if (!Directory.Exists(path))//HttpContext.Current.Server.MapPath("~/TrainData/" + id + "/" + wdb + "/" + "sanitized")))
            {
                Directory.CreateDirectory(path);//HttpContext.Current.Server.MapPath("~/TrainData/" + id + "/" + wdb + "/" + "sanitized"));
            }
            string filename = wdb + "exactdata.html";
            string pathstring = System.IO.Path.Combine(path, filename);
            if (!System.IO.File.Exists(pathstring))
            {
                dr.Close();
                cmd = new SqlCommand(@"select element,attribute,value from Templ_tab where wdb='" + wdb + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    element = dr["element"].ToString();
                    attribute = dr["attribute"].ToString();
                    value = dr["value"].ToString();

                    if (Directory.GetFiles(path1) != null)
                    {
                        foreach (string file in Directory.GetFiles(path1))
                        {

                            HtmlDocument hdoc = new HtmlDocument();
                            hdoc.Load(file);
                            string[] rem = new string[] { "script", "style" };
                            for (int i = 0; i < rem.Length; i++)
                            {
                                foreach (var descendants in hdoc.DocumentNode.Descendants(rem[i]).ToList())
                                {
                                    descendants.Remove();
                                }
                            }
                            IEnumerable<HtmlNode> hnode = hdoc.DocumentNode.Descendants().Where(x => x.Name == element && x.Attributes.Contains(attribute) && x.Attributes[attribute].Value.Split().Contains(value));
                            foreach (var h in hnode)
                            {


                                string tex = h.InnerHtml;
                                tex = tex.Replace("\t", "");
                                tex = tex.Replace("&nbsp;", " ");
                                System.IO.File.AppendAllText(pathstring, tex);
                                //string data = h.InnerText;
                                //data = data.Replace("\t","");
                                //data = data.Replace("\r\n","");
                                //string tag = tex.Replace(data," ");
                                //Data da = new Data(data,tag);
                                
                                // tex = tex.TrimEnd(new char[] { '\t'});
                                
                               // System.IO.File.AppendAllText(pathstring, tex);// + Environment.NewLine);
                            }
                        }
                    }
                }
            }
        }
    }

    public void readFile()
    {
        int id;
        string wdb = "",t="",p="",a="",im="",line="";
        //List<string> title = new List<string>();
        //List<string> author = new List<string>();
        //List<string> price = new List<string>();
        //List<string> img = new List<string>();
        SqlConnection con = new SqlConnection(d.ConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(@"select 1 domain,wdb from registernew", con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            id = Convert.ToInt32(dr["domain"]);
            wdb = dr["wdb"].ToString();
            //  dr.Close();
            string path = HttpContext.Current.Server.MapPath("~/TrainData/" + id + "/" + wdb + "/" + "sanitized" + "/");

            //string pathre = HttpContext.Current.Server.MapPath("~/TrainData/" + id + "/" + wdb + "/" + "Aligned" + "/");
            //if(!Directory.Exists(pathre))
            //{
            //    Directory.CreateDirectory(pathre);//HttpContext.Current.Server.MapPath("~/TrainData/" + id + "/" + wdb + "/" + "Aligned" + "/"));
            //}
            if (Directory.Exists(path))
            {
                if (Directory.GetFiles(path) != null)
                {
                    foreach (string file in Directory.GetFiles(path))
                    {
                       // System.IO.StreamReader sr = new System.IO.StreamReader(file);
                       // while (sr.ReadLine() != null)
                        //{
                            //line = sr.ReadLine();
                            //int start = line.IndexOf("<");
                            //int end = line.IndexOf("</>");

                            //string Value = line.Substring(start) + line.Substring(end, line.Length);
                            //MatchCollection m1 = Regex.Matches(line, @"(<>*</>)", RegexOptions.Singleline);
                            //foreach (Match m in m1)
                            //{
                            //    string val = m.Groups[1].Value;
                            //}
                            // string[] rem = new string[] { "/>" };

                            //   string[] tag = line.Split(rem, StringSplitOptions.RemoveEmptyEntries);

                            HtmlDocument hdoc = new HtmlDocument();
                            hdoc.Load(file);
                            
                            //IEnumerable<HtmlNode> hnode = hdoc.DocumentNode.Descendants();
                           IEnumerable <HtmlNode> hnode = hdoc.DocumentNode.Descendants();
                           foreach (var h in hnode)
                           {

                               //
                               string dataspl = "";
                               string data = h.InnerText;
                               //string test = h.OuterHtml;
                               //string testd = h.InnerHtml;
                               //var hn = hdoc.DocumentNode.SelectNodes("//a");
                               //foreach(var hnn in hn)
                               //{
                               //    hnn.Remove();
                               //}
                              // test = test.Replace(data, "");
                               string _tag = CleanData(h,hdoc);//hdoc.CreateTextNode(h.WriteTo()));//h);
                               if (data != " ")
                               {
                                   data = data.Replace("\r\n", "");
                                   if (data.Contains("by"))
                                   {
                                      // int ind = data.IndexOf("by");
                                       int lastind = data.LastIndexOf("by");

                                       dataspl = data.Substring(lastind);
                                       if (!dataspl.Equals(""))
                                       {
                                           dataspl = dataspl.Substring(2);
                                           if (!dataspl.Equals(""))
                                           {
                                               data = data.Replace(dataspl, "");
                                               data = data.Replace("by", "");
                                           }
                                       }
                                       string tag = h.InnerHtml;
                                       
                                      // tag = tag.Replace("<a href", "");
                                     
                                       tag = tag.Replace("\r\n", "");
                                       int index = tag.LastIndexOf("by");
                                       string[] tagnode = tag.Split(new string[] { "by" }, StringSplitOptions.RemoveEmptyEntries);
                                       if (tagnode.Length == 1)
                                       {
                                           string datatag = tagnode[0];
                                          
                                           Data dat = new Data(data, datatag);
                                       }
                                       else
                                       {
                                          string datatag = tagnode[0];
                                           string dataspltag = tagnode[1];
                                           
                                           Data dat = new Data(data, datatag);
                                           r.add(dat);
                                           w.add(r);
                                          Data datn = new Data(dataspl, dataspltag);
                                          //r.add(datn);
                                          //w.add(r);
                                       }
                                       // datatag = Regex.Replace(datatag, data, "", RegexOptions.IgnoreCase);
                                       //dataspltag = Regex.Replace(dataspltag, dataspl, "", RegexOptions.IgnoreCase);
                                       //tagspl = dataspl.Substring(2);
                                       //tag = tag.Replace(tagspl,"");

                                   }
                                   else
                                   {
                                       string tag = h.InnerHtml;
                                       Data da = new Data(data, tag);
                                       //r.add(da);
                                       //w.add(r);
                                   }
                                   //if (data != null)
                                   //{
                                   //    string tag1 = Regex.Replace(tag, dataspl, "", RegexOptions.IgnoreCase);
                                   //}
                                   //tag = tag.Replace(data, "");
                               }
                           }
                        }
                    }
                }
            }
        //MatchCollection m1 = Regex.Matches(tag, @"<[^>]*>", RegexOptions.Singleline);
        //foreach (Match m in m1)
        //{
        //    tag = " ";

        //}
        // tag.Replace("<[^>]*>", " ");
        // string[] comps = tag.Split(new string[] {"><"},StringSplitOptions.RemoveEmptyEntries);
       // }
            //            //HtmlDocument hdoc = new HtmlDocument();

                        //hdoc.Load(file);

                        //switch (id)
                        //{
                        //    case 1: cmd = new SqlCommand(@"select * from Align_book",con);
                        //         dr = cmd.ExecuteReader();
                               
                        //        while (dr.Read())
                        //        {
                        //             t = dr["title"].ToString();
                        //             a = dr["author"].ToString();
                        //             p = dr["price"].ToString();
                        //             im = dr["img"].ToString();
                        //        }   
                        //        alignContentb(hdoc,t,a,p,im,pathre);
                        //        break;

                        //    case 2: cmd = new SqlCommand(@"select * from Align_ec", con);
                        //        dr = cmd.ExecuteReader();

                        //        while (dr.Read())
                        //        {
                        //            t = dr["productname"].ToString();
                        //            a = dr["brand"].ToString();
                        //            p = dr["price"].ToString();
                        //            im = dr["img"].ToString();
                        //        }
                        //        alignContentec(hdoc, t, a, p, im,pathre);
                        //        break;
                        //}

                                
                            
                       
                    //    if (wdb == "Bookadda")
                    //    {
                    //        IEnumerable<HtmlNode> hnode = hdoc.DocumentNode.Descendants("h4");
                    //        foreach (var h in hnode)
                    //        {
                    //            string data = h.InnerText;
                    //            title.Add(data);
                    //        }
                    //        hnode = hdoc.DocumentNode.Descendants().Where(x => x.Name == "span" && x.Attributes.Contains("class") && x.Attributes["class"].Value.Split().Contains("new_price"));
                    //        foreach (var h in hnode)
                    //        {

                    //            string tex = h.InnerText;
                    //            price.Add(tex);
                    //        }
                    //        hnode = hdoc.DocumentNode.Descendants().Where(x => x.Name == "span" && x.Attributes.Contains("class") && x.Attributes["class"].Value.Split().Contains("prodAuthor"));
                    //        foreach (var h in hnode)
                    //        {

                    //            string tex = h.InnerText;
                    //            tex = tex.Replace("\t", "");
                    //            tex = tex.Replace("\r", "");
                    //            tex = tex.Replace("\n", "");
                    //            tex = tex.Replace("by", "");
                    //            author.Add(tex);
                    //        }


                    //        img = (from x in hdoc.DocumentNode.Descendants() where x.Name.ToLower() == "img" select x.Attributes["src"].Value).ToList<String>();

                    //        string pathre = HttpContext.Current.Server.MapPath("~/TrainData/" + id + "/" + wdb + "/" + "Aligned");
                    //        string filnamet = "title.text";
                    //        string filnamea = "author.text";
                    //        string filnamep = "price.text";
                    //        string filnamei = "image.text";
                    //        string fpath1 = System.IO.Path.Combine(pathre, filnamet);
                    //        string fpath2 = System.IO.Path.Combine(pathre, filnamea);
                    //        string fpath3 = System.IO.Path.Combine(pathre, filnamep);
                    //        string fpath4 = System.IO.Path.Combine(pathre, filnamei);
                    //        foreach (var v in title)
                    //        {
                    //            //dt.Rows.Add(v);
                    //            System.IO.File.AppendAllText(fpath1, v + Environment.NewLine);
                    //        }
                    //        foreach (var v in author)
                    //        {
                    //            System.IO.File.AppendAllText(fpath2, v + Environment.NewLine);
                    //        }
                    //        foreach (var v in price)
                    //        {
                    //            System.IO.File.AppendAllText(fpath3, v + Environment.NewLine);
                    //        }
                    //        foreach (var v in img)
                    //        {
                    //            System.IO.File.AppendAllText(fpath4, v + Environment.NewLine);
                    //        }
                    //        // }
                    //    }
                    //    else if (wdb == "Landmarkonthenet")
                    //    {
                    //        IEnumerable<HtmlNode> hnode = hdoc.DocumentNode.Descendants("h1");
                    //        foreach (var h in hnode)
                    //        {
                    //            string data = h.InnerText;
                    //            title.Add(data);
                    //        }
                    //        hnode = hdoc.DocumentNode.Descendants("h2");
                    //        foreach (var h in hnode)
                    //        {
                    //            string data = h.InnerText;
                    //            data = data.Replace("by", "");
                    //            author.Add(data);
                    //        }
                    //        hnode = hdoc.DocumentNode.Descendants().Where(x => x.Name == "span" && x.Attributes.Contains("class") && x.Attributes["class"].Value.Split().Contains("pricelabel"));
                    //        foreach (var h in hnode)
                    //        {

                    //            string tex = h.InnerText;
                    //            price.Add(tex);
                    //        }
                    //        img = (from x in hdoc.DocumentNode.Descendants() where x.Name.ToLower() == "img" select x.Attributes["src"].Value).ToList<String>();

                    //        string pathre = HttpContext.Current.Server.MapPath("~/TrainData/" + id + "/" + wdb + "/" + "Aligned");
                    //        string filnamet = "title.text";
                    //        string filnamea = "author.text";
                    //        string filnamep = "price.text";
                    //        string filnamei = "image.text";
                    //        string fpath1 = System.IO.Path.Combine(pathre, filnamet);
                    //        string fpath2 = System.IO.Path.Combine(pathre, filnamea);
                    //        string fpath3 = System.IO.Path.Combine(pathre, filnamep);
                    //        string fpath4 = System.IO.Path.Combine(pathre, filnamei);
                    //        foreach (var v in title)
                    //        {
                    //            //dt.Rows.Add(v);
                    //            System.IO.File.AppendAllText(fpath1, v + Environment.NewLine);
                    //        }
                    //        foreach (var v in author)
                    //        {
                    //            System.IO.File.AppendAllText(fpath2, v + Environment.NewLine);
                    //        }
                    //        foreach (var v in price)
                    //        {
                    //            System.IO.File.AppendAllText(fpath3, v + Environment.NewLine);
                    //        }
                    //        foreach (var v in img)
                    //        {
                    //            System.IO.File.AppendAllText(fpath4, "http:" + v + Environment.NewLine);
                    //        }
                    //    }
                    //    else if (wdb == "Uread")
                    //    {
                    //        IEnumerable<HtmlNode> hnode = hdoc.DocumentNode.Descendants().Where(x => x.Name == "div" && x.Attributes.Contains("class") && x.Attributes["class"].Value.Split().Contains("title"));
                    //        foreach (var h in hnode)
                    //        {
                    //            string data = h.InnerText;
                    //            title.Add(data);
                    //        }
                    //        hnode = hnode = hdoc.DocumentNode.Descendants().Where(x => x.Name == "span" && x.Attributes.Contains("class") && x.Attributes["class"].Value.Split().Contains("author-publisher"));
                    //        foreach (var h in hnode)
                    //        {
                    //            string data = h.InnerText;
                    //            if (data.Contains("by"))
                    //            {
                    //                data = data.Replace("by", "");
                    //                author.Add(data);
                    //            }
                    //        }
                    //        hnode = hdoc.DocumentNode.Descendants().Where(x => x.Name == "div" && x.Attributes.Contains("class") && x.Attributes["class"].Value.Split().Contains("sell"));
                    //        foreach (var h in hnode)
                    //        {

                    //            string tex = h.InnerText;
                    //            price.Add(tex);
                    //        }
                    //        img = (from x in hdoc.DocumentNode.Descendants() where x.Name.ToLower() == "img" select x.Attributes["src"].Value).ToList<String>();

                    //        string pathre = HttpContext.Current.Server.MapPath("~/TrainData/" + id + "/" + wdb + "/" + "Aligned");
                    //        string filnamet = "title.text";
                    //        string filnamea = "author.text";
                    //        string filnamep = "price.text";
                    //        string filnamei = "image.text";
                    //        string fpath1 = System.IO.Path.Combine(pathre, filnamet);
                    //        string fpath2 = System.IO.Path.Combine(pathre, filnamea);
                    //        string fpath3 = System.IO.Path.Combine(pathre, filnamep);
                    //        string fpath4 = System.IO.Path.Combine(pathre, filnamei);
                    //        foreach (var v in title)
                    //        {
                    //            //dt.Rows.Add(v);
                    //            System.IO.File.AppendAllText(fpath1, v + Environment.NewLine);
                    //        }
                    //        foreach (var v in author)
                    //        {
                    //            System.IO.File.AppendAllText(fpath2, v + Environment.NewLine);
                    //        }
                    //        foreach (var v in price)
                    //        {
                    //            System.IO.File.AppendAllText(fpath3, v + Environment.NewLine);
                    //        }
                    //        foreach (var v in img)
                    //        {
                    //            System.IO.File.AppendAllText(fpath4, v + Environment.NewLine);
                    //        }
                    //    }

                  //  }
              // }
            //}
            //else
            //{

            //}
        }
   // }

    //public void alignContentb(HtmlDocument hdoc,string t,string a,string p,string im,string pathre)
    //{
    //    List<string> title = new List<string>();
    //    List<string> author = new List<string>();
    //    List<string> price = new List<string>();
    //    List<string> img = new List<string>();
    //    string[] sep = new string[] { "-" };
    //    string[] rest = t.Split(sep, StringSplitOptions.RemoveEmptyEntries);
    //    string[] resa = a.Split(sep, StringSplitOptions.RemoveEmptyEntries);
    //    string[] resp = p.Split(sep, StringSplitOptions.RemoveEmptyEntries);
    //    string[] resim = im.Split(sep, StringSplitOptions.RemoveEmptyEntries);
    //    IEnumerable<HtmlNode> hnode;
    //    if (rest.Length == 1)
    //    {
    //        hnode = hdoc.DocumentNode.Descendants(rest[0]);
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;
    //            title.Add(data);
    //        }
    //    }
    //    else
    //    {
    //        hnode = hdoc.DocumentNode.Descendants().Where(x => x.Name == rest[0] && x.Attributes.Contains(rest[1]) && x.Attributes[rest[1]].Value.Split().Contains(rest[2]));
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;
    //            title.Add(data);
    //        }
    //    }
    //    if (resa.Length == 1)
    //    {
    //        hnode = hdoc.DocumentNode.Descendants(resa[0]);
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;
    //            data = data.Replace("by", "");
    //            author.Add(data);
    //        }
    //    }
    //    else
    //    {
    //        hnode = hdoc.DocumentNode.Descendants().Where(x => x.Name == resa[0] && x.Attributes.Contains(rest[1]) && x.Attributes[resa[1]].Value.Split().Contains(resa[2]));
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;
    //            data = data.Replace("by", "");
    //            author.Add(data);
    //        }
    //    }
    //    if (resp.Length == 1)
    //    {
    //        hnode = hdoc.DocumentNode.Descendants(resp[0]);
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;
    //            price.Add(data);
    //        }
    //    }
    //    else
    //    {
    //        hnode = hdoc.DocumentNode.Descendants().Where(x => x.Name == resp[0] && x.Attributes.Contains(resp[1]) && x.Attributes[resp[1]].Value.Split().Contains(resp[2]));
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;
                
    //            price.Add(data);
    //        }
    //    }
    //    if (resim.Length == 1)
    //    {

    //        hnode = hdoc.DocumentNode.Descendants(resim[0]);
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;
    //            img.Add(data);
    //        }
    //    }
    //    else
    //    {
    //        img = (from x in hdoc.DocumentNode.Descendants() where x.Name.ToLower() == resim[0] select x.Attributes[resim[1]].Value).ToList<String>();
            
    //    }
   
    //    string filnamet = "title.text";
    //    string filnamea = "author.text";
    //    string filnamep = "price.text";
    //    string filnamei = "image.text";
    //    string fpath1 = System.IO.Path.Combine(pathre, filnamet);
    //    string fpath2 = System.IO.Path.Combine(pathre, filnamea);
    //    string fpath3 = System.IO.Path.Combine(pathre, filnamep);
    //    string fpath4 = System.IO.Path.Combine(pathre, filnamei);
    //    foreach (var v in title)
    //    {
            
    //        System.IO.File.AppendAllText(fpath1, v + Environment.NewLine);
    //    }
    //    foreach (var v in author)
    //    {
    //        System.IO.File.AppendAllText(fpath2, v + Environment.NewLine);
    //    }
    //    foreach (var v in price)
    //    {
    //        System.IO.File.AppendAllText(fpath3, v + Environment.NewLine);
    //    }
    //    foreach (var v in img)
    //    {
    //        System.IO.File.AppendAllText(fpath4, v + Environment.NewLine);
    //    }
    //}

    //public void alignContentec(HtmlDocument hdoc, string t, string a, string p, string im, string pathre)
    //{
    //    List<string> productname = new List<string>();
    //    List<string> brand = new List<string>();
    //    List<string> price = new List<string>();
    //    List<string> img = new List<string>();
    //    string[] sep = new string[] { "-" };
    //    string[] rest = t.Split(sep, StringSplitOptions.RemoveEmptyEntries);
    //    string[] resa = a.Split(sep, StringSplitOptions.RemoveEmptyEntries);
    //    string[] resp = p.Split(sep, StringSplitOptions.RemoveEmptyEntries);
    //    string[] resim = im.Split(sep, StringSplitOptions.RemoveEmptyEntries);
    //    IEnumerable<HtmlNode> hnode;
    //    if (rest.Length == 1)
    //    {
    //        hnode = hdoc.DocumentNode.Descendants(rest[0]);
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;
    //            productname.Add(data);
    //        }
    //    }
    //    else
    //    {
    //        hnode = hdoc.DocumentNode.Descendants().Where(x => x.Name == rest[0] && x.Attributes.Contains(rest[1]) && x.Attributes[rest[1]].Value.Split().Contains(rest[2]));
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;
    //            productname.Add(data);
    //        }
    //    }
    //    if (resa.Length == 1)
    //    {
    //        hnode = hdoc.DocumentNode.Descendants(resa[0]);
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;
    //                brand.Add(data);
                
    //        }
    //    }
    //    else
    //    {
    //        hnode = hdoc.DocumentNode.Descendants().Where(x => x.Name == resa[0] && x.Attributes.Contains(rest[1]) && x.Attributes[resa[1]].Value.Split().Contains(resa[2]));
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;
    //            //data = data.Replace("by", "");
    //            brand.Add(data);
    //        }
    //    }
    //    if (resp.Length == 1)
    //    {
    //        hnode = hdoc.DocumentNode.Descendants(resp[0]);
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;
    //            price.Add(data);
    //        }
    //    }
    //    else
    //    {
    //        hnode = hdoc.DocumentNode.Descendants().Where(x => x.Name == resp[0] && x.Attributes.Contains(resp[1]) && x.Attributes[resp[1]].Value.Split().Contains(resp[2]));
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;

    //            price.Add(data);
    //        }
    //    }
    //    if (resim.Length == 1)
    //    {

    //        hnode = hdoc.DocumentNode.Descendants(resim[0]);
    //        foreach (var h in hnode)
    //        {
    //            string data = h.InnerText;
    //            img.Add(data);
    //        }
    //    }
    //    else
    //    {
    //        img = (from x in hdoc.DocumentNode.Descendants() where x.Name.ToLower() == resim[0] select x.Attributes[resim[1]].Value).ToList<String>();

    //    }

    //    string filnamet = "productname.text";
    //    string filnamea = "description.text";
    //    string filnamep = "price.text";
    //    string filnamei = "image.text";
    //    string fpath1 = System.IO.Path.Combine(pathre, filnamet);
    //    string fpath2 = System.IO.Path.Combine(pathre, filnamea);
    //    string fpath3 = System.IO.Path.Combine(pathre, filnamep);
    //    string fpath4 = System.IO.Path.Combine(pathre, filnamei);
    //    foreach (var v in productname)
    //    {

    //        System.IO.File.AppendAllText(fpath1, v + Environment.NewLine);
    //    }
    //    foreach (var v in brand)
    //    {
    //        System.IO.File.AppendAllText(fpath2, v + Environment.NewLine);
    //    }
    //    foreach (var v in price)
    //    {
    //        System.IO.File.AppendAllText(fpath3, v + Environment.NewLine);
    //    }
    //    foreach (var v in img)
    //    {
    //        System.IO.File.AppendAllText(fpath4, v + Environment.NewLine);
    //    }
    //}
    private string CleanData(HtmlNode h,HtmlDocument hdoc)
    {
        string full = h.InnerHtml;
       // string splfull = "";
        if (h.HasChildNodes)
        {
            foreach (HtmlNode hn in h.Descendants())
            {
                CleanData(hn,hdoc);
            }

        }
        else
        {
           // h.Text = null;
           HtmlTextNode hn= hdoc.CreateTextNode(h.WriteTo());
           hn.Text = "";
            //splfull=full.Replace(h.Text, "");
            
        }
        return h.InnerHtml;
        //return splfull;
    }
}
