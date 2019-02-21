using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dozor .BL;
using System.Threading;
using System.Globalization;
using WebApplication1;
using Dozor.BL.Managers;
using System.Net.Mail;

namespace Dozor 
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        private String first = string.Empty;
        protected String First { get { return first; } }

        private String second = string.Empty;
        protected String Second { get { return second; } }

        private String third = string.Empty;
        protected String Third { get { return third; } }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            


            try
            {

              

                var winnerTeams = TeamManager.GetOrderedTeamsLastGame();
                first = "1. " + winnerTeams[0].Name + "  " + winnerTeams[0].Result;
                second = "2. " + winnerTeams[1].Name + "  " + winnerTeams[1].Result;
                third = "3. " + winnerTeams[2].Name + "  " + winnerTeams[2].Result;

                if (Session["culture"] != null)
                {
                    if (Session["culture"] == "en-US")
                        SetLanguage("EN");
                    else
                        SetLanguage("RU");
                }
                else
                {
                    Session["culture"] = "en-US";
                    SetLanguage("EN");
                }

            }
            catch (Exception ex)
            {
            }
            
        }
              

        public void SetEnglish_Click(object sender, EventArgs e)
        {
            Session["culture"] = "en-US";
            SetLanguage("EN");
            Server.Transfer(Request.Url.PathAndQuery, false);
        }

        public void SetRussian_Click(object sender, EventArgs e)
        {
            Session["culture"] = "ru-RU";
            SetLanguage("RU");
            Server.Transfer(Request.Url.PathAndQuery, false);
        }


        private void SetLanguage(String language)
        {
            if (language == "EN")
            {
                P1.Visible = 
                Ul1.Visible = 
                Div1.Visible = 
                Div3.Visible =
                Div5.Visible =
                Div7.Visible =
                P3.Visible = true;

                P2.Visible =
                Ul2.Visible =
                Div2.Visible = 
                Div4.Visible =
                Div6.Visible =
                Div8.Visible =
                P4.Visible = false;

            }
            else
            {
               P1.Visible =
               Ul1.Visible =
               Div1.Visible =
               Div3.Visible =
               Div5.Visible =
               Div7.Visible =
               P3.Visible = false;

                P2.Visible =
                Ul2.Visible =
                Div2.Visible =
                Div4.Visible =
                Div6.Visible =
                Div8.Visible =
                P4.Visible = true;
            }
        }

        protected void bSend_Click(object sender, EventArgs e)
        {
            var phoneSender = string.Empty;
            if (!String.IsNullOrEmpty(phone.Value))
                phoneSender = phone.Value;
            else
                phoneSender = phone1.Value;

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("look.and.run.fi@gmail.com");
            msg.To.Add("look.and.run.fi@gmail.com");
            msg.Subject = "Contact!";
            msg.Body = "Hello! \n\n Call number  " + phoneSender + ".";
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("look.and.run.fi@gmail.com", "76026Andrey");
            client.Timeout = 20000;
            try
            {
                client.Send(msg);
                string url = Request.Url.GetLeftPart(UriPartial.Path);
                url += "?showpopup=sent";
                Response.Redirect(url);
            }
            catch (Exception ex)
            {
                if (!ex.GetType().IsAssignableFrom(typeof(System.Threading.ThreadAbortException)))
                {
                    string url = Request.Url.GetLeftPart(UriPartial.Path);
                    url += "?showpopup=fail";
                    Response.Redirect(url);
                }
            }
            finally
            {
                msg.Dispose();
            }
        }
    }
}
