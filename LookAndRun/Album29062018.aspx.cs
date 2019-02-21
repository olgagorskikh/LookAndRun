using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Album29062018 : System.Web.UI.Page
    {
        private int n = 36;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var newCode = string.Empty;

                for (int i = 1; i <= n; i++)
                {
                    newCode += @"<a href='http://lookandrun.fi/Albums/29062018/" + i + @".jpg' class='fancybox photo' rel='gallery1'>
                            <img class='img-responsive' src='http://lookandrun.fi/Albums/29062018/_" + i + @".jpg' alt=''></a>";
                }
                photosCustom.InnerHtml += newCode;
            }

        }
    }
}