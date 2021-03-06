﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3
{
    public partial class ListMortgages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IIOHelper iOHelper = new FileIOHelper();
            var list = iOHelper.ListAllMortgages();

            if (list.Count == 0)
            {
                list.Add("No Data stored!");
            }

            GridView1.DataSource = list;
            GridView1.DataBind();

        }
    }
}