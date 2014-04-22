using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Data.SqlClient;

namespace LikesBank
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string token;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["code"] != null)
            {
                HtmlControl shit = (HtmlControl)Page.FindControl("w2");
                shit.Visible = true;
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
                g.Close();
                token = b.Split('&')[0].Split('=')[1].Split(' ')[0];
                HttpWebRequest EMAIL = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/me?fields=email&access_token="+token);
                EMAIL.Method = "GET";
                StreamReader s = new StreamReader(EMAIL.GetResponse().GetResponseStream());
                u = "";
                b = "";
                while (u != null)
                {
                    u = g.ReadLine();
                    if (u != null)
                        b += u;
                }
                string email = b.Split('"')[3];
                HtmlControl shit2 = (HtmlControl)Page.FindControl("w2");
                shit2.Visible = true;
                TextBox1.Text = email;

            }
        }

        protected void connect()
        {

                HttpWebRequest fuck = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/oauth/access_token?client_id=237726383082723&redirect_uri=http://likesbank.apphb.com/webform1.aspx&client_secret=0420278b8f5a0985ba21458afac9e257&code=" + Request.QueryString["code"]);
                StreamReader g = new StreamReader(fuck.GetResponse().GetResponseStream());
                string u = "";
                string b = "";
                while (u != null)
                {

                }
                g.Close();
                token = b.Split('&')[0].Split('=')[1].Split(' ')[0];
               

                

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            HtmlControl shit = (HtmlControl)Page.FindControl("w1");
            shit.Visible = true;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            HtmlControl shit = (HtmlControl)Page.FindControl("w1");
            shit.Visible = false;
        }
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("https://www.facebook.com/dialog/oauth?client_id=237726383082723&redirect_uri=http://likesbank.apphb.com/webform1.aspx&response_type=code&scope=publish_actions");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection("68b-91f3-a31200847454.sqlserver.sequelizer.com;Database=db74b317f397db468b91f3a31200847454;User ID=okuodvwkvgtzfduc;Password=TdH4qo2H7SDuFgNatGkbKKu8zBYhYsE5zZ4jXEwuDpJwuG3SHVJN6VCiRJCWxTRM;");
            SqlCommand com2 = new SqlCommand("INSERT INTO emails (email) VALUES (@a)", con);
            com2.Parameters.Add("@a", System.Data.SqlDbType.VarChar).Value = TextBox1.Text;

            com2.ExecuteNonQuery();
            Response.Redirect("http://likesbank.apphb.com/liker.aspx?token="+token+"&website="+TextBox2.Text+"&likes="+(CheckBox1.Checked?"yes":"no")+"&shares="+(CheckBox2.Checked?"yes":"no"))
        }
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            HtmlControl shit = (HtmlControl)Page.FindControl("w2");
            shit.Visible = false;
        }


    }
}