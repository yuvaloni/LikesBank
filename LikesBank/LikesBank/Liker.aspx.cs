using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Data.SqlClient;
namespace LikesBank
{
    public partial class Liker : System.Web.UI.Page
    {
        string token;
        string site;
        string likes;
        string shares;
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        public void work()
        {
            token = Request.QueryString["token"];
            site = Request.QueryString["site"];
            likes = Request.QueryString["likes"];
            shares = Request.QueryString["shares"];
            SqlDataReader sqlr;
            SqlCommand com;
            SqlConnection con = new SqlConnection("Data Source=74b317f3-97db-468b-91f3-a31200847454.sqlserver.sequelizer.com;Initial Catalog=db74b317f397db468b91f3a31200847454;Persist Security Info=True;User ID=okuodvwkvgtzfduc;Password=TdH4qo2H7SDuFgNatGkbKKu8zBYhYsE5zZ4jXEwuDpJwuG3SHVJN6VCiRJCWxTRM");
            con.Open();
            if (likes == "yes")
            {
                com = new SqlCommand("SELECT * FROM session", con);
                sqlr = com.ExecuteReader();
                while (sqlr.Read())
                {

                        if (sqlr.GetString(3) == "yes")
                        {
                            HttpWebRequest LIKER = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/me/og.likes");
                            LIKER.Method = "POST";
                            StreamWriter likestream = new StreamWriter(LIKER.GetRequestStream());
                            LIKER.ContentType = "text";

                            likestream.Write("object=" + sqlr.GetString(2) + "&access_token=" + token);
                            likestream.Close();
                            LIKER.GetResponse();
                            LIKER = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/me/og.likes");
                            LIKER.Method = "POST";
                            likestream = new StreamWriter(LIKER.GetRequestStream());
                            LIKER.ContentType = "text";

                            likestream.Write("object=" + site + "&access_token=" + sqlr.GetString(1));
                            likestream.Close();
                            LIKER.GetResponse();
                        }

                }
                sqlr.Close();
                
            }
            if (shares == "yes")
            {
                com = new SqlCommand("SELECT * FROM session", con);
                sqlr = com.ExecuteReader();
                while (sqlr.Read())
                {
                          if (sqlr.GetString(4) == "yes")
                        {
                            HttpWebRequest LIKER = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/me/links");
                            LIKER.Method = "POST";
                            StreamWriter likestream = new StreamWriter(LIKER.GetRequestStream());
                            LIKER.ContentType = "text";

                            likestream.Write("link=" + sqlr.GetString(2) + "&access_token=" + token);
                            likestream.Close();
                            LIKER.GetResponse();
                            LIKER = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/me/links");
                            LIKER.Method = "POST";
                            likestream = new StreamWriter(LIKER.GetRequestStream());
                            LIKER.ContentType = "text";

                            likestream.Write("link=" + site + "&access_token=" + sqlr.GetString(1));
                            likestream.Close();
                            LIKER.GetResponse();
                        }

                }
                sqlr.Close();

            }
                SqlCommand com2 = new SqlCommand("INSERT INTO [session] (token, website,likes,shares) VALUES (@t,@w,@l,@s)", con);
                com2.Parameters.Add("@t", System.Data.SqlDbType.VarChar).Value = token;
                com2.Parameters.Add("@w", System.Data.SqlDbType.VarChar).Value = site;
                com2.Parameters.Add("@l", System.Data.SqlDbType.VarChar).Value = likes;
                com2.Parameters.Add("@s", System.Data.SqlDbType.VarChar).Value = shares;
                com2.ExecuteNonQuery();
            con.Close();
            Response.Write("Done! Feel free to close the window");
        }
    }
}