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
    public partial class LastResults : System.Web.UI.Page
    {
        private List<Team> teamList = new List<Team>();
        protected IList<Team> TeamList { get { return teamList; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (Session["culture"] == null)
                    Session["culture"] = "en-US";
                InitializeCulture();

                var lastGame = GameManager.GetLastGame();
                Header.Text = lastGame.Data;

                if (!String.IsNullOrEmpty(lastGame.Event))
                    fbLink.HRef = lastGame.Event;
                else
                    fbLink.Visible = false;

                if (!String.IsNullOrEmpty(lastGame.Photo))
                    fbPhoto.HRef = lastGame.Photo;
                else
                    fbPhoto.Visible = false;

                BindGridView();
            }
            catch (Exception ex)
            {
                fbLink.Visible = false;
                fbPhoto.Visible = false;
            }
                        
        }


        private void BindGridView()
        {
             teamList = TeamManager.GetOrderedTeamsLastGame();
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
     
    }
}