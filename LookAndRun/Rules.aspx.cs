﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

namespace WebApplication1
{
    public partial class Rules : System.Web.UI.Page
    {
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
                        English.Visible = false;
                        Russian.Visible = true;

                    }
                }
                else
                {
                    Session["culture"] = "en-US";
                    English.Visible = true;
                    Russian.Visible = false;
                }


                InitializeCulture();

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
    }
}