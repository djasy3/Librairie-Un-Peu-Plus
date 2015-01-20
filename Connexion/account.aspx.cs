using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Connexion_account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //on définit le titre de la page
        this.Title = LibConfig.NomSite + ": Créer un compte";
    }
    //
    protected void creerCompte(object sender, EventArgs e)
    {
        Roles.AddUserToRole((sender as CreateUserWizard).UserName, "Utilisateurs");//on ajoute un utilisateur normale
    }
}