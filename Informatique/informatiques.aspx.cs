using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Informatique_Informatique : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //on obtient la liste des livres informatique
        ListInfo.DataSource = PresentationLivres.GetInfo();
        //on charge les data dans la listeview
        ListInfo.DataBind();

    }
}