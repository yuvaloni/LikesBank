﻿using System;
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

            if (Request.QueryString["code"] == null)
                Response.Redirect("https://www.facebook.com/dialog/oauth?client_id=237726383082723&redirect_uri=http://likesbank.apphb.com/webform1.aspx&response_type=code");
            else
            {
                HttpWebRequest fuck = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/oauth/access_token?client_id=237726383082723&redirect_uri=http://likesbank.apphb.com/webform1.aspx&client_secret=0420278b8f5a0985ba21458afac9e257&code=" + Request.QueryString["code"]);
                StreamReader g = new StreamReader(fuck.GetResponse().GetResponseStream());
                string u = "";
                string b = "";
                while (u != null)
                {
                    u = g.ReadLine();
                    if (u != null)
                        b += u;

                }
                string token = b.Split('&')[0].Split('=')[1].Split(' ')[0];
                 HttpWebRequest LIKER = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/me/og.likes");
               StreamWriter likestream = new StreamWriter(LIKER.GetRequestStream());
                LIKER.Method="POST";
                likestream.Write("object=http://likesbank.apphb.com&access_token="+token);
                Response.Write(token);
                
            }

        }
    }
}