using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Technologies_Technologies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //liste de tous livres sur la technologie
        ListTechno.DataSource = PresentationLivres.GetTechno();
        //on charge la liste
        ListTechno.DataBind();
    }
}