using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

namespace LikesBank
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string shit = (Request.QueryString["code"]);
            if (shit == null)
                Response.Redirect("https://www.facebook.com/dialog/oauth?client_id=237726383082723&redirect_uri=http://http://likesbank.apphb.com/webform1.aspx&response_type=code");
            else
            {
                HttpWebRequest fuck = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/oauth/access_token");
                fuck.Method = "GET";
                StreamWriter p = new StreamWriter(fuck.GetRequestStream());
                p.Write(string.Format("client_id={0}&redirect_uri={1}&client_secret={2}&code={3})", "237726383082723", "http://http://likesbank.apphb.com/webform1.aspx", "0420278b8f5a0985ba21458afac9e257", Request.Params["code"].ToString()));
                StreamReader g = new StreamReader(fuck.GetResponse().GetResponseStream());
                string u = "";
                while (u != null)
                {
                    u = g.ReadLine();
                    if (u != null)
                        Response.Write(u + "\n");

                }
            }
                Response.Write("null");
        }
    }
}