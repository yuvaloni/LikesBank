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
            if (Session["token"] != null)
                token = (string)Session["token"];
            if (Session["site"] != null)
                TextBox2.Text = (string)Session["site"];
            else
                Session["site"] = TextBox2.Text;
            Session["email"] = TextBox1.Text;
            if (Session["email"] != null)
                TextBox1.Text = (string)Session["email"];
            Session["l"] = CheckBox1.Checked;
            if (Session["l"] != null)
                CheckBox1.Checked = (bool)Session["l"];
            Session["s"] = CheckBox2.Checked;
            if (Session["s"] != null)
                CheckBox2.Checked = (bool)Session["s"];
            if (Request.QueryString["code"] != null && token==null)
            {

                HttpWebRequest fuck = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/oauth/access_token?client_id=237726383082723&redirect_uri=http://likesbank.apphb.com/Default.aspx&client_secret=0420278b8f5a0985ba21458afac9e257&code=" + Request.QueryString["code"]);
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
                Session["token"] = token;
                HttpWebRequest EMAIL = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/me?fields=email&access_token="+token);
                EMAIL.Method = "GET";
                StreamReader s = new StreamReader(EMAIL.GetResponse().GetResponseStream());
                u = "";
                b = "";
                while (u != null)
                {
                    u = s.ReadLine();
                    if (u != null)
                        b += u;
                }
                s.Close();
                string email = b.Split('"')[3];
                HtmlControl shit2 = (HtmlControl)Page.FindControl("w2");
                shit2.Visible = true;
                TextBox1.Text = email;

            }
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
            Response.Redirect("https://www.facebook.com/dialog/oauth?client_id=237726383082723&redirect_uri=http://likesbank.apphb.com/Default.aspx&response_type=code&scope=publish_actions");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=74b317f3-97db-468b-91f3-a31200847454.sqlserver.sequelizer.com;Initial Catalog=db74b317f397db468b91f3a31200847454;Persist Security Info=True;User ID=okuodvwkvgtzfduc;Password=TdH4qo2H7SDuFgNatGkbKKu8zBYhYsE5zZ4jXEwuDpJwuG3SHVJN6VCiRJCWxTRM");
            con.Open();
            SqlCommand com2 = new SqlCommand("INSERT INTO emails(email) VALUES(@a);", con);
            com2.Parameters.Add("@a", System.Data.SqlDbType.Text).Value = TextBox1.Text;

            com2.ExecuteNonQuery();
            con.Close();
            Response.Redirect("http://likesbank.apphb.com/Liker.aspx?token=" + token + "&website=" + TextBox2.Text + "&likes=" + (CheckBox1.Checked ? "yes" : "no") + "&shares=" + (CheckBox2.Checked ? "yes" : "no"));
        }
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            HtmlControl shit = (HtmlControl)Page.FindControl("w2");
            shit.Visible = false;
        }


    }
}