using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;
using Dozor.BL.Managers;
using Dozor.BL;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Dozor
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            RegistrDiv.Visible = false;
            lClosed.Visible = true;            

                try
                {
                   
                    if (Session["culture"] == null)
                        Session["culture"] = "en-US";
                     InitializeCulture();

                    var nextGame = GameManager.GetNextGame();
                    lDate.Text = nextGame.Data;
                }

                catch (Exception ex)
                {
                    lDate.Visible = false;
                }

            }

            
        

        protected override void InitializeCulture()
        {
            base.InitializeCulture();
            if (Session["culture"] != null)
            {
                CultureInfo ci = new CultureInfo(Session["culture"].ToString());
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
            }
        }

        
        protected void Register_Click(object sender, EventArgs e)
        {
           
            try
            {
                var numofMembers = Int32.Parse(members.Value);

                var nextGame = GameManager.GetNextGame();
                var gameId = nextGame.Id;

                var teamName = teamname.Value;
                var mobile = mobilenumber.Value;
                var selectedLan = language.Value;

                var team = new Team(0, gameId, selectedLan, teamName, mobile, numofMembers);
                var flag = (String.IsNullOrEmpty(team.Name) || String.IsNullOrEmpty(team.Mobile));
                if (!flag)
                {
                    var teamId = TeamManager.InsertTeam(team);
                }
                else
                {
                    string url1 = Request.Url.GetLeftPart(UriPartial.Path);
                    url1 += "?showpopup=fail";
                    Response.Redirect(url1);
                }
                    
                ClearFields();
                SendEmail(teamName, numofMembers, selectedLan);
                string url = Request.Url.GetLeftPart(UriPartial.Path);
                url += "?showpopup=ok";
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
                
            
        }

        private void SendEmail(string team, int numofMembers, string language)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("look.and.run.fi@gmail.com");
            msg.To.Add("look.and.run.fi@gmail.com");
            msg.Subject = "!!!";
            msg.Body = team + ", "+numofMembers+", "+language+" registered!";
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
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                msg.Dispose();
            }
        }

        private void ClearFields()
        {
            members.Value = "1";
            teamname.Value=
            mobilenumber.Value=
            language.Value= String.Empty;

        }
       
    }
}