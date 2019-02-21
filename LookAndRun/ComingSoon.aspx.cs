using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dozor.BL.Managers;
using System.Globalization;
using System.Threading;
using System.ComponentModel;
using Dozor.BL;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class ComingSoon : System.Web.UI.Page
    {
        private List<Team> teamList = new List<Team>();
        protected IList<Team> TeamList { get { return teamList; } }

        private String fbEvent = string.Empty;
        protected String FbEvent { get { return fbEvent; } }



        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                if (Session["culture"] != null)
                {
                    if (Session["culture"] == "en-US")
                    {
                        English.Visible = true;
                        Russian.Visible = false;
                           
                    }
                    else
                    {
                        English.Visible =  false;
                        Russian.Visible =  true;
                            
                    }
                }
                else
                {
                    Session["culture"] = "en-US";
                    English.Visible = true;
                    Russian.Visible = false;
                }

                InitializeCulture();

                BindGridView();
                var nextGame = GameManager.GetNextGame();

                if (!String.IsNullOrEmpty(nextGame.Event))
                    fbLink.HRef = nextGame.Event;
                else
                    fbLink.Visible = false;

               

            }

            catch (Exception ex)
            {
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

        private void BindGridView()
        {
            teamList = TeamManager.GetTeamsNextGame();
        }
               
               
    }
}