﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Album16042016 : System.Web.UI.Page
    {
        private int n = 43;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var newCode = string.Empty;

                for (int i = 1; i <= n; i++)
                {
                    newCode += @"<a href='http://lookandrun.fi/Albums/16042016/" + i + @".jpg' class='fancybox photo' rel='gallery1'>
                            <img class='img-responsive' src='http://lookandrun.fi/Albums/16042016/_" + i + @".jpg' alt=''></a>";
                }
                photosCustom.InnerHtml += newCode;
            }

        }
    }
}