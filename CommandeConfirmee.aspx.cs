using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CommandeConfirmee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //on définit le titre de la page
        this.Title = LibConfig.NomSite + ":commande confirmée";
    }
    //
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
}