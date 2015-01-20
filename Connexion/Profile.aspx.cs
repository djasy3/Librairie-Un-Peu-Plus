using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Connexion_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //on définit le nom de la page du site
        this.Title = LibConfig.NomSite + "Détails utilisateur";
    }
}